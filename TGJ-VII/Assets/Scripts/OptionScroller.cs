using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScroller : MonoBehaviour {

    public List<string> options;
    public int selectedOptionInt;
    public string selectedOption;

	// Use this for initialization
	void Start () {

    selectedOption = options[selectedOptionInt];
    GetComponentInChildren<Text>().text = options[selectedOptionInt];
    }
	
	// Update is called once per frame
	public void Update ()
    {
		
	}

    public void CycleRight()
    {
        if (selectedOptionInt == options.Count -1)
        {
            selectedOptionInt = 0;
        }

        else
            selectedOptionInt++;

        GetComponentInChildren<Text>().text = options[selectedOptionInt];
        selectedOption = GetComponentInChildren<Text>().text = options[selectedOptionInt];
    }

    public void CycleLeft()
    {
        if (selectedOptionInt == 0)
        {
            selectedOptionInt = options.Count -1;
        }

        else
            selectedOptionInt--;

        GetComponentInChildren<Text>().text = options[selectedOptionInt];
        selectedOption = GetComponentInChildren<Text>().text = options[selectedOptionInt];
    }
}
