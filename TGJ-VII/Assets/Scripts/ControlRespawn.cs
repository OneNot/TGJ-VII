using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRespawn : MonoBehaviour {

    private GameObject[] tubeDudet;
    private Vector3 spawnPosition;
    public GameObject controllableDude;
    

    public void ControlSwap()
    {
        Debug.Log("ControlAccessed");
        if (GameObject.FindGameObjectWithTag("ControlledDude") == null)
        {
            Debug.Log("ControlAccessed2");
            tubeDudet = GameObject.FindGameObjectsWithTag("TubeDude");


            foreach (GameObject tubeDude in tubeDudet)
            {
                Debug.Log("ControlAccessed3");
                if (tubeDude.GetComponent<TubeDudeBehavior>().isControllable == true)
                {
                    Debug.Log("ControlAccessed4");
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
