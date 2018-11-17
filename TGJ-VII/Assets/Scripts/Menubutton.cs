using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menubutton : MonoBehaviour {

    public GameObject nextSelectable;
    public GameObject previousSelectable;
    public GameObject UIController;

    public GameObject rightSelectable;
    public GameObject leftSelectable;
     
    //Nämä ovat sitä varten, että nappulat vaihtuvat esim. settings valikossa pelin tilasta riippuen
    public string disableButton;
    public string enableButton;

    // Etsitään tesktiobjekti ja ylikirjoitetaan se esim: --> Back --> Resume
    public string overrideTextObject;
    public string overrideTextMessage;

    // Vastaavan niminen paneeli, jonka nappula avaa
    public string openPanel;
    // Painike joka uudessa valikossa on aktiivinen
    public string defaultActiveButton;

    //Tämä on nappuloiden paluutoimintoa varten. Ei pelkästään esc, kaikki jotka käyttävät "Cancel"
    public bool listensToEsc;

    public string SceneName;


    


	// Use this for initialization
	void Start () {
        UIController = GameObject.Find("UIController");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(listensToEsc == true && UIController.GetComponent<UIController>().gameActive == false && gameObject.GetComponentInParent<Canvas>().enabled == true) 
        {
            if (Input.GetButtonDown("Cancel"))
            {
                UIController.GetComponent<UIController>().enable = false;
                gameObject.GetComponent<Selectable>().Select();
                gameObject.GetComponent<Button>().onClick.Invoke();
            }

        }
        
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

            if(gameObject.GetComponentInParent<Canvas>()!=null)
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

        else if(UIController.GetComponent<UIController>().gameActive == false)
            ResumeGame();
      
        
    }

    //Palautuu päävalikkoon tai lopettaa pelin jos ollaan siellä


    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.GetComponentInParent<Canvas>().enabled = false;
        UIController.GetComponent<UIController>().gameActive = true;
        UIController.GetComponent<UIController>().lastState = "Resumed";
    }

    public void EnableButton()
    {
        UIController.GetComponent<UIController>().ActivateButton(enableButton);
    }

    public void DisableButton()
    {
        UIController.GetComponent<UIController>().DisableButton(disableButton);
    }

    public void StartScene()
    {
        UIController.GetComponent<UIController>().gameActive = true;
        SceneManager.LoadScene(SceneName);
        gameObject.GetComponentInParent<Canvas>().enabled = false;
    }

    public void QuitToMenu()
    {
        Destroy(GameObject.Find("Settings"));
        Destroy(GameObject.Find("Mainmenu"));
        Destroy(GameObject.Find("UIController"));
        Destroy(GameObject.Find("EventSystem"));
        SceneManager.LoadScene("Mainmenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
