using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuubiRotator : MonoBehaviour {

    public List<GameObject> DudesInRange;

    [Tooltip("How many times a second to check")]
    public int ChecksPerSecond = 5;

    private float lastCheckTime = 0f;
    private Transform closestDudeTransform;
    private float? closestDudeDistance;

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
                    closestDudeTransform = o.transform;
                }
            }
            //=== closest dude transform check END ===

            transform.LookAt(closestDudeTransform); //Look at the closest dude

            //clean the values for next time
            closestDudeDistance = null;
            closestDudeTransform = null;
        }


		
	}
}
