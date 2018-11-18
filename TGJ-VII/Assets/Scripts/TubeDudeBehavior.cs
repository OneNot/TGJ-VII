using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDudeBehavior : MonoBehaviour
{

    private Rigidbody rb;
    public float moveSpeed;
    public float roamSpeed;
    public float roamDelay;
    public float dudeFollowRange;
    public float dudeFollowCap;
    float playerDist;
    private GameObject controlledDude;
    private ParticleSystem.EmissionModule parSysEm;

    //Variables used for spawn protection
    float origoDist;
    public float spawnArea;
    bool spawnProtected = true;
    Vector3 startPosition;

    bool isFlagged = false;
    bool isWandering = false;
    bool isFollowing = true;
    public bool inSuckerRange;
    public bool isControllable;

    public float flagRange;
    public float flagCap;
    private GameObject flag;
    private float flagDist;

    // Use this for initialization
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        startPosition = transform.position;
        //parSysEm = GetComponentInChildren<ParticleSystem>().emission;
        //parSysEm.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        flag = GameObject.FindGameObjectWithTag("Flag");
        controlledDude = GameObject.FindGameObjectWithTag("ControlledDude");
        BehaviorCheck();
    }


    public void BehaviorCheck()
    {
        //------------
        //This block is to determine when to wander
        if (isWandering == true && isFlagged == false && isFollowing == false)
        {
            //Calls the function to wander around
            WanderAround();
        }
        else if (isWandering == false)
        {
            //Makes the dudes wander if there's nothing else to do
            isWandering = true;
        }
        //-------------

        //-------------
        if (flag != null)
        {
            float flagDist = Vector3.Distance(flag.transform.position, transform.position);
            if (flagDist < flagRange)
            {
                isFlagged = true;

                //if not currently emmiting, start
                /*
                if(!parSysEm.enabled)
                {
                    parSysEm.enabled = true;
                }
                */
            }
            else
            {
                isFlagged = false;
            }
        }

        //This part determines to follow the flag, if it's in distance
        if (isFlagged == true)
        {
            FollowFlag();
        }
        //-------------

        //-------------
        if (controlledDude != null)
        {
            playerDist = Vector3.Distance(controlledDude.transform.position, transform.position);

            if (dudeFollowRange > playerDist && isFlagged == false)
            {
                isFollowing = true;
                spawnProtected = false;
                isControllable = true;
                isWandering = false;

                //if not currently emmiting, start
                /*
                if (!parSysEm.enabled)
                {
                    parSysEm.enabled = true;
                }
                */
            }

            if (isFollowing == true && isFlagged == false)
            {
                //Calls the function to follow player
                FollowMaster();
            }
        }
        //-------------
    }

    public void FollowMaster()
    {
        Vector3 posToLookAt = controlledDude.transform.position; //get pure position
        posToLookAt.y = transform.position.y; //set pos y to own y, thus causing the difference to always be 0 and so no rotation is applied 
        transform.LookAt(posToLookAt);
        playerDist = Vector3.Distance(controlledDude.transform.position, transform.position);
        if (playerDist < dudeFollowRange && playerDist > dudeFollowCap)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            isFollowing = false;
        }
    }

    public void FollowFlag()
    {
        if (flag != null)
        {
            flagDist = Vector3.Distance(flag.transform.position, transform.position);
            transform.LookAt(flag.transform);
            if (flagDist > flagCap)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            isFlagged = false;
        }
    }

    public void WanderAround()
    {
        /*
        //if currently emmiting, stop
        if (parSysEm.enabled)
        {
            parSysEm.enabled = false; //stop emmiting particles if start wandering
        }

        //when wandering set "is controllable" to false if it isn't already =====
        if(isControllable)
        {
            isControllable = false;
        }
        */
        //=======================================================================

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

    public void StopEffect()
    {
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    public void ActivateRagdoll()
    {
        //dunno how w'll do this yet
    }
}
