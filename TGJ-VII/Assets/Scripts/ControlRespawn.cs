using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRespawn : MonoBehaviour {

    private GameObject[] tubeDudet;
    private Vector3 spawnPosition;
    public GameObject controllableDude;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ControlSwap()
    {
        if (GameObject.FindGameObjectWithTag("ControlledDude") == null)
        {
            tubeDudet = GameObject.FindGameObjectsWithTag("TubeDude");

            foreach (GameObject tubeDude in tubeDudet)
            {
                if (tubeDude.GetComponent<TubeDudeBehavior>().isControllable == true)
                {
                    spawnPosition = tubeDude.transform.position;
                    Destroy(tubeDude);
                    GameObject target = Instantiate(controllableDude, spawnPosition, Quaternion.Euler(Vector3.zero));
                    Camera.main.GetComponent<CameraScript>().ReSetFollowing(target.transform);
                    break;
                }
            }
        }
    }
}
