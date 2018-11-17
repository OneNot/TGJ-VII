using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRespawn : MonoBehaviour {

    private GameObject[] tubeDudet;
    public bool isControllable;
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
        Debug.Log("Success1");
        if (GameObject.FindGameObjectWithTag("ControlledDude") == null)
        {
            Debug.Log("Success2");
            tubeDudet = GameObject.FindGameObjectsWithTag("TubeDude");

            foreach (GameObject tubeDude in tubeDudet)
            {
                Debug.Log("Success3");
                if (tubeDude.GetComponent<TubeDudeBehavior>().isControllable == true)
                {
                    Debug.Log("Success4");
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
