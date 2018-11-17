using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerDetector : MonoBehaviour {

    private TuubiRotator rotator;

    private void Start()
    {
        rotator = transform.parent.GetComponent<TuubiRotator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("TubeDude"))
        {
            rotator.DudesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TubeDude"))
        {
            rotator.DudesInRange.Remove(other.gameObject);
        }
    }
}
