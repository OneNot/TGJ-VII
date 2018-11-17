using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRespawn : MonoBehaviour {

    private GameObject[] tubeDudet;
    public bool isControllable;
    private bool searchDone;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DeathDetect()
    {
        if (GameObject.FindGameObjectsWithTag("ControlledDude") == null)
        {
            tubeDudet = GameObject.FindGameObjectsWithTag("TubeDude");

            do
            {
                foreach (GameObject tubeDude in tubeDudet)
                {
                    
                }
            } while (searchDone == false);
        }
    }
}
