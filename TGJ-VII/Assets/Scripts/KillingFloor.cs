using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingFloor : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TubeDude"))
        {
            TubeDudeBehavior brainToKill = other.gameObject.GetComponent<TubeDudeBehavior>();
            //brainToKill.ActivateRagdoll();
            brainToKill.gameObject.tag = "DeadDude";
            brainToKill.StopEffect();
            brainToKill.enabled = false; //lobotomize
        }
        else if(other.gameObject.CompareTag("ControlledDude"))
        {
            PlayerController brainToKill = other.gameObject.GetComponent<PlayerController>();
            other.gameObject.tag = "DeadDude";
            GameObject.FindGameObjectWithTag("SpawnController").GetComponent<ControlRespawn>().ControlSwap();
            brainToKill.StopEffect();
            brainToKill.enabled = false;
        }
    }
}
