using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour {

    public Transform FollowTarget;
    public float MoveSpeed;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(transform.position + ((FollowTarget.position - transform.position).normalized * Time.deltaTime * MoveSpeed));
        transform.LookAt(FollowTarget);
    }
}
