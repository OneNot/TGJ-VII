using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAudioListenerThing : MonoBehaviour {

    public GameObject juttu;

    private void Awake()
    {
        if(GameObject.Find(juttu.name) == null && GameObject.Find(juttu.name + "(Clone)") == null)
        Instantiate(juttu);
    }

    // Use this for initialization
    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
