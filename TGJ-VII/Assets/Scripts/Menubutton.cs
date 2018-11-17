using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menubutton : MonoBehaviour {

    public GameObject nextSelectable;
    public GameObject previousSelectable;


    // Etsitään tesktiobjekti ja ylikirjoitetaan se esim: --> Back --> Resume
    public string overrideTextObject;
    public string overrideTextMessage;

    // Vastaavan niminen paneeli, jonka nappula avaa
    public string openPanel;
    // Painike joka uudessa valikossa on aktiivinen
    public string defaultActiveButton;

    


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        


        
    }

    //Aktivoi nappulan, korostaen valintaa
    public void Activate()
    {
        gameObject.GetComponent<Button>().Select();
    }

   

    //Avaa toisen menupaneelin ja sulkee nykyisen.
    public void OpenPanel()
    {

        if (overrideTextObject != "")
        {
            GameObject.Find(overrideTextObject).GetComponent<Text>().text = overrideTextMessage;
        }


        if (GameObject.Find(openPanel) != null)
        {
            GameObject.Find(openPanel).GetComponent<Canvas>().enabled = true;
            gameObject.GetComponentInParent<Canvas>().enabled = false;
        }

        if(defaultActiveButton != "")
        {
            GameObject.Find("UIController").GetComponent<UIController>().targetSelectable = GameObject.Find(defaultActiveButton);
        }
    }


    //Palautuu päävalikkoon tai takaisin peliin, riippuen onko päävalikossa
    public void BackToMainOrGame()
    {
        if(SceneManager.GetActiveScene().name == "Mainmenu")
        {
            GameObject.Find("Mainmenu").GetComponent<Canvas>().enabled = true;
            gameObject.GetComponentInParent<Canvas>().enabled = false;

            GameObject.Find("UIController").GetComponent<UIController>().targetSelectable = GameObject.Find(defaultActiveButton);
        }

        /*else
        { 
            gameObject.GetComponentInParent<Canvas>().enabled = false;
            //Resume toiminto
        }
        */
    }

    //Palautuu päävalikkoon tai lopettaa pelin jos ollaan siellä
    public void BackToMainOrQuit()
    {

    }
}
