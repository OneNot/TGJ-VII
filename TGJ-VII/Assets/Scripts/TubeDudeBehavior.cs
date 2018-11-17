using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDudeBehavior : MonoBehaviour {

    private Rigidbody rb;
    public float moveSpeed = 1;
    public float rotSpeed = 1;
    public float roamSpeed;
    public float roamDelay;
    public float dudeFollowRange;
    public float dudeFollowCap;
    float playerDist;
    private GameObject controlledDude;

    //Variables used for spawn protection
    float origoDist;
    public float spawnArea; 
    bool spawnProtected = true;
    Vector3 startPosition;

    bool isFlagged = false;
    bool isWandering = false;
    bool isFollowing = true;
    public bool inSuckerRange;

    public float flagRange;
    public float flagCap;
    //bool flagTooClose = false;
    private GameObject flag;
    private float flagDist;

    // Use this for initialization
    void Start () {
        rb = transform.GetComponent<Rigidbody>();
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        PlayerDistance();
        FlagCheck();
        BehaviorCheck();
        flag = GameObject.FindGameObjectWithTag("Flag");

    }

    public void PlayerDistance()
    {
        if (flag != null)
        {
            playerDist = Vector3.Distance(flag.transform.position, transform.position);
            if (playerDist < dudeFollowRange)
            {
                isFollowing = true;
                isWandering = false;
            }

            else if (playerDist > dudeFollowRange)
            {
                isFollowing = false;
                isWandering = true;
            }
        }
    }

    public void FlagCheck()
    {
        if (flag != null)
        {
            float flagDist = Vector3.Distance(flag.transform.position, transform.position);
            if (flagDist < flagRange)
            {
                isFlagged = true;
            }
        }
    }

    public void BehaviorCheck() {
        //This serie of if -statements are to determine what the AI is doing and should do.
        //If the AI is doing nothing, start wondering
        //If the AI is following, execute following code
        //If it's wandering, execute wandering code
        if (isWandering == false)
        {
            if (isFollowing == false)
            {
                isWandering = true;
            }

            else if (isFollowing == true)
            {
                //Calls the function to follow player
                FollowTarget();
                spawnProtected = false;
            }
        }
        else if (isWandering == true)
        {
            //Calls the function to wander around
            WanderAround();
        }
    }

    public void FollowTarget()
    {
        if (flag != null)
        {
            flagDist = Vector3.Distance(flag.transform.position, transform.position);
            if (!isFlagged)
            {
                transform.LookAt(flag.transform);
                if (flagRange > flagDist && flagCap < flagDist)
                {
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("ControlledDude").transform);
            playerDist = Vector3.Distance(GameObject.FindGameObjectWithTag("ControlledDude").transform.position, transform.position);
            if (playerDist > dudeFollowCap)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
    }

    public void FollowFlag()
    {
        if (flag != null)
        {
            flagDist = Vector3.Distance(flag.transform.position, transform.position);

        }
        else
        {
            if (flag != null && flagCap < flagDist)
            {
                Debug.Log("pysyn");
            }
        }
    }


    public void WanderAround()
    {
        if (spawnProtected)
        {
            origoDist = Vector3.Distance(startPosition, transform.position);
            if (origoDist > spawnArea)
            {
                transform.LookAt(startPosition);
                transform.Translate(Vector3.forward * roamSpeed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(WanderAroundRotate());
                StartCoroutine(WanderAroundWalk());
            }
        }
        else
        {
            StartCoroutine(WanderAroundRotate());
            StartCoroutine(WanderAroundWalk());
        }
    }

    //Bool value used for timing coroutine properly
    bool running = false;

    private IEnumerator WanderAroundRotate()
    {
        if (!running)
        {
            running = true;
            yield return new WaitForSeconds(roamDelay);

            Vector3 euler = transform.eulerAngles;
            euler.y = Random.Range(0f, 360f);
            transform.eulerAngles = euler;
            running = false;
        }
    }


    private IEnumerator WanderAroundWalk()
    {
        if (running)
        {
            transform.Translate(Vector3.forward * roamSpeed * Time.deltaTime);
            yield return new WaitForSeconds(roamDelay);
        }
    }
}
