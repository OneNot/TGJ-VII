using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodyMessScript : MonoBehaviour {

    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - startTime > 3)
        {
            Destroy(gameObject);
        }
	}
}
