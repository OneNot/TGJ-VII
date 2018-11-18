using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed, LookSpeed, FlagDeSpawnDelay;
    public GameObject FlagPrefab;

    private Rigidbody rb;
    private Vector3 input;
    private float inputHor, inputVer, flagPlantTime = 0f;
    private bool plantFlagInput, flagPlanted = false;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        inputHor = Input.GetAxis("Horizontal");
        inputVer = Input.GetAxis("Vertical");

        plantFlagInput = Input.GetButtonDown("PlantFlag");

        if (plantFlagInput && !flagPlanted)
        {
            Instantiate(FlagPrefab, transform.position, Quaternion.Euler(Vector3.zero));
            flagPlanted = true;
            flagPlantTime = Time.time;
        }
        else if (plantFlagInput && flagPlanted && (Time.time - flagPlantTime > FlagDeSpawnDelay))
        {
            Destroy(GameObject.FindGameObjectWithTag("Flag"));
            flagPlanted = false;
        }


        input = new Vector3(inputHor, 0f, inputVer);
        if (input != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(input), 0.15F);


    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + input * Time.deltaTime * MoveSpeed);
    }

    public void StopEffect()
    {
        GetComponentInChildren<ParticleSystem>().Stop();
    }
}
