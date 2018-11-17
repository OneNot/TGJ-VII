using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKiller : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("TubeDude"))
        {
            transform.parent.gameObject.GetComponent<TuubiRotator>().DudesInRange.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
