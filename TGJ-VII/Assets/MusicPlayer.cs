using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private AudioSource aS;

	// Use this for initialization
	void Start () {
        aS = GetComponent<AudioSource>();
        aS.volume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        aS.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
