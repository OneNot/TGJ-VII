using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menuslider : MonoBehaviour {


    //Teksti joka korvaa lapsessa olevan tekstin, esim "Volume: "
    public string sliderText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        print(AudioListener.volume);
	}

    public void SliderUpdateText()
    {
        GetComponentInChildren<Text>().text = sliderText + gameObject.GetComponent<Slider>().value;
    }

    public void SliderAdjustVolume()
    {
        AudioListener.volume = gameObject.GetComponent<Slider>().value / 100;
    }
}
