﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDudeBehavior : MonoBehaviour {

    private Rigidbody rb;
    public float moveSpeed = 1;
    public float roamSpeed;
    public float roamDelay;
    public float dudeFollowRange;
    public float dudeFollowCap;
    float playerDist;

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
    void Start() {
        rb = transform.GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        BehaviorCheck();
        flag = GameObject.FindGameObjectWithTag("Flag");
    }


    public void BehaviorCheck() {

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
        playerDist = Vector3.Distance(GameObject.FindGameObjectWithTag("ControlledDude").transform.position, transform.position);
        if (dudeFollowRange > playerDist && isFlagged == false)
        {
            isFollowing = true;
        }

        if (isFollowing == true && isFlagged == false)
        {
            //Calls the function to follow player
            FollowMaster();
            spawnProtected = false;
        }
        //-------------
    }

    public void FollowMaster()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("ControlledDude").transform);
        playerDist = Vector3.Distance(GameObject.FindGameObjectWithTag("ControlledDude").transform.position, transform.position);
        if (playerDist < dudeFollowRange)
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

    public void ActivateRagdoll()
    {
        //dunno how w'll do this yet
    }
}
