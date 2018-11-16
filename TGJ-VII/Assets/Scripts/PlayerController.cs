using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed, LookSpeed;

    private Rigidbody rb;
    private Vector3 input, prevLoc;
    private float inputHor, inputVer;
    private bool plantFlagInput;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        inputHor = Input.GetAxis("Horizontal");
        inputVer = Input.GetAxis("Vertical");
        plantFlagInput = Input.GetButtonDown("PlantFlag");

        input = new Vector3(inputHor, 0f, inputVer);
        rb.MovePosition(transform.position + input * Time.deltaTime * MoveSpeed);
        if(input != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(input), 0.15F);


    }
}
