﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leikkujri : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * 50 * Time.deltaTime, Space.Self);
    }
}