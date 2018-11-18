﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicHandler : MonoBehaviour {


	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);

	}
	
	// Update is called once per frame
	void Update () {

        //print(PlayerPrefs.GetFloat("BGMVolume"));

        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMVolume");
            
        if(Camera.main != null)
        {
            gameObject.transform.parent = Camera.main.transform;

        }

        

	}
}
