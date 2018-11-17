using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerScript : MonoBehaviour {

    private SphereCollider rotatorCollider;
    private BoxCollider suckerCollider;
    private Vector3 closestDude;
    private float? closestDudeDistance;

	// Use this for initialization
	void Start () {
        rotatorCollider = GetComponent<SphereCollider>();
        suckerCollider = GetComponents<BoxCollider>()[1]; //second (index 1) box collider is the sucker. first is the actual collider of the pipe
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("TubeDude"))
        {
            Vector3 thisDude = other.gameObject.transform.position;
            float thisDudeDistance = Vector3.Distance(thisDude, transform.position);

            if (thisDudeDistance > closestDudeDistance || closestDudeDistance == null)
            {
                closestDudeDistance = thisDudeDistance;
                closestDude = thisDude;

                transform.LookAt(closestDude);
                print(other.gameObject.name);
            }
        }
    }
}
