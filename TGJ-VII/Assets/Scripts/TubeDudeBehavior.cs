using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDudeBehavior : MonoBehaviour {

    private Rigidbody rb;
    public float moveSpeed = 1;
    public float rotSpeed = 1;
    public float roamSpeed;
    public float roamDelay;
    public float roamWalkDuration;
    public float dudeFollowRange;
    public float dudeFollowCap;
    float playerDist;


    bool isFlagged = false;
    bool spawnProtected = true;
    bool isWandering = false;
    bool isFollowing = true;

	// Use this for initialization
	void Start () {
        rb = transform.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        PlayerDistance();
        BehaviorCheck();
	}

    public void PlayerDistance()
    {
        playerDist = Vector3.Distance(GameObject.FindGameObjectWithTag("ControlledDude").transform.position, transform.position);
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
                FollowMaster();
            }
        }
        else if (isWandering == true)
        {
            //Calls the function to wander around
            StartCoroutine(WanderAroundRotate());
            StartCoroutine(WanderAroundWalk());
            
        }
    }

    public void FollowMaster()
    {
        
        transform.LookAt(GameObject.FindGameObjectWithTag("ControlledDude").transform);

        playerDist = Vector3.Distance(GameObject.FindGameObjectWithTag("ControlledDude").transform.position, transform.position);
        if (playerDist < dudeFollowCap)
        {
            
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
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
