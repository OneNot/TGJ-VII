using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingFloor : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TubeDude"))
        {
            TubeDudeBehavior brainToKill = other.gameObject.GetComponent<TubeDudeBehavior>();
            brainToKill.ActivateRagdoll();
            brainToKill.gameObject.tag = "DeadDude";
            brainToKill.enabled = false; //lobotomize
        }
        else if(other.gameObject.CompareTag("ControlledDude"))
        {
            other.gameObject.tag = "DeadDude";
        }
    }
}
