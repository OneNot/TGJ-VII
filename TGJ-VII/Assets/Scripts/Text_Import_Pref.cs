using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Import_Pref : MonoBehaviour {

    public bool text;
    public string prefName;

    public string advanced_Basetext;
    public bool score;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (score == false)
        {
            if (text == true)
                GetComponent<Text>().text = PlayerPrefs.GetString(prefName, "");

            else
                GetComponent<Text>().text = PlayerPrefs.GetInt(prefName, 0).ToString();
        }

        if(score == true)
        {
            GetComponent<Text>().text = advanced_Basetext + GameObject.Find("ScoreController").GetComponent<ScoreController>().currentScore;

        }
    }
}
