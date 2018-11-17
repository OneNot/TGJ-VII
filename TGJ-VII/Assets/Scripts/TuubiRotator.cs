using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuubiRotator : MonoBehaviour {

    public List<GameObject> DudesInRange;

    [Tooltip("How many times a second to check for closest dude")]
    public int ChecksPerSecond = 5;
    public float TurnSpeed;

    private float lastCheckTime = 0f;
    private Vector3 closestDudePos;
    private float? closestDudeDistance;
    private Vector3 prevClosestDudePos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(Time.time - lastCheckTime > 1/ChecksPerSecond)
        {
            //=== Get the transform of the closest dude ===//
            foreach (GameObject o in DudesInRange)
            {
                float newDudeDistance = Vector3.Distance(transform.position, o.transform.position);
                //if current dude is closer than previous closest
                if (newDudeDistance < closestDudeDistance || closestDudeDistance == null)
                {
                    closestDudeDistance = newDudeDistance;
                    closestDudePos = o.transform.position;
                    closestDudePos.y = transform.position.y; //basically indirectly contrains the rotation to only the y axel
                }
            }
            closestDudeDistance = null; //needs to be cleaned for next time
            //=== closest dude transform check END ===            
        }

        //if we have values for current closest and previous closest, slerp move the pipe
        if(prevClosestDudePos != null && closestDudePos != null)
            transform.LookAt(Vector3.Slerp(prevClosestDudePos, closestDudePos, Time.deltaTime * TurnSpeed));

        if(closestDudePos != null)
            prevClosestDudePos = closestDudePos; //update previous closest
	}
}
