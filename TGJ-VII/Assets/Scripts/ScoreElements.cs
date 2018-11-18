using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreElements : MonoBehaviour {

    GameObject scoreController;
    GameObject UIController;

	// Use this for initialization
	void Start () {

        scoreController = GameObject.Find("ScoreController");
        UIController = GameObject.Find("UIController");
    }
	
	// Update is called once per frame
	void Update () {

        if (scoreController.GetComponent<ScoreController>().currentScore > PlayerPrefs.GetInt("Top5Score"))
        {
            UIController.GetComponent<UIController>().ActivateButton(gameObject.name);
        }

        else
        {
            UIController.GetComponent<UIController>().DisableButton(gameObject.name);
        }



	}
}
