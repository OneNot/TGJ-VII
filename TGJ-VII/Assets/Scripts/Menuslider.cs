using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menuslider : MonoBehaviour {


    //Teksti joka korvaa lapsessa olevan tekstin, esim "Volume: "
    public string sliderText;
    public string adaptPrefValue;
    public float adaptPrefValueMultiplier = 1;
    public string setPrefValue;
    public float prefDefaultValue;
    public int divideBy = 1;
    public int additionalDivider;

    // Use this for initialization
    void Start () {
        if (adaptPrefValue != "")
        {
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat(adaptPrefValue, prefDefaultValue) * adaptPrefValueMultiplier * divideBy;
            if (additionalDivider != 0)
                gameObject.GetComponent<Slider>().value /= additionalDivider;

            SliderUpdateText();
        }

        
	}
	
	// Update is called once per frame
	void Update () {

        //print(AudioListener.volume);
	}

    public void SliderUpdateText()
    {
        GetComponentInChildren<Text>().text = sliderText + gameObject.GetComponent<Slider>().value;
    }

    public void SliderAdjustVolume()
    {
        AudioListener.volume = gameObject.GetComponent<Slider>().value / 100;
        PlayerPrefs.SetFloat("MasterVolume", gameObject.GetComponent<Slider>().value);
    }

    public void SetPrefValue()
    {
        PlayerPrefs.SetFloat(setPrefValue, gameObject.GetComponent<Slider>().value / divideBy);
    }
}
