using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leikkujri : MonoBehaviour {

    public GameObject BloodyMessPrefabRef;

    public float speed;
    public float spinningSpeed;
    public float OnHitPitchDuration = 0.2f;
    public float HowMuchToPitch = 2.5f;
    public float volumeDivider = 4f;

    private float pitchUpTime;
    private bool pitched;
    private AudioSource aS;

	void Start () {
        aS = GetComponent<AudioSource>();
        aS.volume = PlayerPrefs.GetFloat("SFXVolume", 1f) / volumeDivider;
        aS.Play();
	}
	
	void Update () {
        transform.Rotate(Vector3.right * spinningSpeed * 100 * Time.deltaTime, Space.Self); //Terän pyörittäminen
        transform.Translate(transform.parent.transform.forward * speed * Time.deltaTime, Space.World); //terän liikuttaminien

        if (pitched && Time.time - pitchUpTime > OnHitPitchDuration)
        {
            aS.pitch = 1f;
            pitched = false;
        }
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
            brainToKill.StopEffect();
            aS.pitch = HowMuchToPitch;
            pitchUpTime = Time.time;
            pitched = true;
            Instantiate(BloodyMessPrefabRef, other.transform.position, Quaternion.Euler(Vector3.zero)); //spawns a bloody explosion (handles removal itself afterwards)
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("ControlledDude"))
        {
            print("ded");
            PlayerController brainToKill = other.gameObject.GetComponent<PlayerController>();
            other.gameObject.tag = "DeadDude";
            GameObject.FindGameObjectWithTag("SpawnController").GetComponent<ControlRespawn>().ControlSwap();
            brainToKill.StopEffect();
            aS.pitch = 1.8f;
            pitchUpTime = Time.time;
            pitched = true;
            Instantiate(BloodyMessPrefabRef, other.transform.position, Quaternion.Euler(Vector3.zero)); //spawns a bloody explosion (handles removal itself afterwards)
            Destroy(other.gameObject);
        }

    }
}
