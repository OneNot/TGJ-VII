using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leikkujri : MonoBehaviour {

    public float speed;
    public float spinningSpeed;


	// Use this for initialization
	void Start () {
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.parent.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * spinningSpeed * speed * Time.deltaTime, Space.Self);
        transform.Translate(transform.parent.transform.forward * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("SpinnerBox"))
            speed *= -1;
    }
}
