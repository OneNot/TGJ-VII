using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    [Tooltip("Multiplies the distance of the camera from the player.\n 1 == the distance set in the editor, 0.5 being half that etc.")]
    public float DistanceMultiplier = 1f;

    private Transform following;
    private Vector3 distance;

	// Use this for initialization
	void Start () {
        following = GameObject.FindGameObjectWithTag("ControlledDude").transform;
        distance = transform.position - following.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = following.position + distance * DistanceMultiplier;
	}

    public void ReSetFollowing(Transform _newFollowedTransform)
    {
        following = _newFollowedTransform;
    }
}
