using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leikkujri : MonoBehaviour {

    public float speed;
    public float spinningSpeed;

	void Start () {
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.parent.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); Turha mutta pidä varmuuden vuoksi mukana jos tarvitsee johonkin
	}
	
	void Update () {
        transform.Rotate(Vector3.right * spinningSpeed * speed * Time.deltaTime, Space.Self); //Terän pyörittäminen
        transform.Translate(transform.parent.transform.forward * speed * Time.deltaTime, Space.World); //terän liikuttaminien
    }

    //terän menosuunnan vaihto
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("SpinnerBox"))
            speed *= -1;

        if(other.gameObject.CompareTag("TubeDude"))
        {
            TubeDudeBehavior brainToKill = other.gameObject.GetComponent<TubeDudeBehavior>();
            //brainToKill.ActivateRagdoll();
            brainToKill.gameObject.tag = "DeadDude";
            brainToKill.enabled = false; //lobotomize
        }
        else if (other.gameObject.CompareTag("ControlledDude"))
        {
            other.gameObject.tag = "DeadDude";
            GameObject.FindGameObjectWithTag("SpawnController").GetComponent<ControlRespawn>().ControlSwap();
            other.gameObject.GetComponent<PlayerController>().enabled = false;
        }

    }
}
