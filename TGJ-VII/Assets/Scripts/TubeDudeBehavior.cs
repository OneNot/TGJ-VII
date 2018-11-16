using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDudeBehavior : MonoBehaviour {

    public float moveSpeed = 1;
    public float rotSpeed = 1;

    bool isWandering = false;
    bool isFollowing = true;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        BehaviorCheck();
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
            WanderAround();
        }
    }

    public void FollowMaster()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("ControlledDude").transform);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void WanderAround()
    {

    }
}
