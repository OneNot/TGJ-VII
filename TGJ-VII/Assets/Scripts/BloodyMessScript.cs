using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodyMessScript : MonoBehaviour {

    private float startTime;
    private AudioSource aS;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        aS = GetComponent<AudioSource>();
        aS.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        aS.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - startTime > 3)
        {
            Destroy(gameObject);
        }
	}
}
