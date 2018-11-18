using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputField : MonoBehaviour {

    public GameObject ScoreController;
    public Text text;

    // Use this for initialization
    void Start() {

        ScoreController = GameObject.Find("ScoreController");
    }

    // Update is called once per frame
    void Update() {

        //print(text.text);
       
    }

    public void UpdatePlayerName()
    {
        ScoreController.GetComponent<ScoreController>().playerName = text.text;
    }
}
