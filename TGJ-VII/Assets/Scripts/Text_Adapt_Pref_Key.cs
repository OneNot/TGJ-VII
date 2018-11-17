using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Adapt_Pref_Key : MonoBehaviour {

    public string prefKeyName;
    public float defaultValue;
    public float multiplier = 1;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text += " " + PlayerPrefs.GetFloat(prefKeyName, defaultValue) * multiplier;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
