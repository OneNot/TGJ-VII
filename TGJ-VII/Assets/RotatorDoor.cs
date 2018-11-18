using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorDoor : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime);
	}
}
