using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucker : MonoBehaviour {

    private Vector3 eyeOfTheStorm;
    public float Succ = 10;

	// Use this for initialization
	void Start () {
        eyeOfTheStorm = transform.GetChild(0).transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("TubeDude"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce((eyeOfTheStorm - other.gameObject.transform.position).normalized * Time.deltaTime * Succ);
        }
    }
}
