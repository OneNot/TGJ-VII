using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIController : MonoBehaviour
{
    //Tarkistaa onko peli päällä, eikä esim paused
    public bool gameActive;
    public string lastState = "Resumed";

    public bool enable = true;

    bool verticalAxisAvailable;
    bool horizontalAxisAvailable;

    public bool textFieldActive;

    public GameObject targetSelectable;

    private void Awake()
    {
        //Käytä tätä testaamaan, että oletusasetukset iskeytyvät oikein
        //PlayerPrefs.DeleteAll();
    }

    // Use this for initialization
    void Start () {
    
        targetSelectable = GameObject.Find("Mainmenu_defaultselectable");
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
	}

    void Update()
    {
        
        if (Input.GetButtonDown("Fire3"))
            EndGame("Victory");
        if (Input.GetButtonDown("Fire2"))
            GameObject.Find("ScoreController").GetComponent<ScoreController>().GiveScore(10);
    }


    void LateUpdate ()
    {
        //if(targetSelectable != null)
        //print(targetSelectable.name);

        if (Input.GetButtonDown("Cancel") && gameActive == true && lastState == "Resumed" && enable == true)
        {
                PauseGame();
        }

        enable = true;

        if (Input.GetAxis("Vertical") == 0)
            verticalAxisAvailable = true;

        if (Input.GetAxis("Horizontal") == 0)
            horizontalAxisAvailable = true;



        if (Input.GetAxisRaw("Vertical") == -1 && verticalAxisAvailable == true && textFieldActive == false)
        {
            verticalAxisAvailable = false;

            if (targetSelectable != null)
            {
                if (targetSelectable.GetComponent<Menubutton>().nextSelectable != null && targetSelectable.GetComponent<Menubutton>().nextSelectable.GetComponent<Selectable>().enabled == true)
                {
                    targetSelectable.GetComponent<Menubutton>().nextSelectable.GetComponentInChildren<Selectable>().Select();
                    targetSelectable = targetSelectable.GetComponent<Menubutton>().nextSelectable;
                }
            }

        }

        if (Input.GetAxisRaw("Vertical") == 1 && verticalAxisAvailable == true && textFieldActive == false)
        {
            verticalAxisAvailable = false;

            if (targetSelectable != null)
            {
                if (targetSelectable.GetComponent<Menubutton>().previousSelectable != null && targetSelectable.GetComponent<Menubutton>().previousSelectable.GetComponent<Selectable>().enabled == true)
                {
                    targetSelectable.GetComponent<Menubutton>().previousSelectable.GetComponentInChildren<Selectable>().Select();
                    targetSelectable = targetSelectable.GetComponent<Menubutton>().previousSelectable;
                }
            }

        }

        if (Input.GetAxisRaw("Horizontal") == -1 && textFieldActive == false)
        {
            if (targetSelectable != null)
            {
                if (targetSelectable.GetComponent<Menubutton>() != null && horizontalAxisAvailable == true)
                {
                    if (targetSelectable.GetComponent<Menubutton>().SelectorBox == true)
                        targetSelectable.GetComponentInParent<OptionScroller>().CycleLeft();
                }


                if (targetSelectable.GetComponentInParent<Slider>() != null)
                {
                    targetSelectable.GetComponentInParent<Slider>().value--;
                }

                else if (targetSelectable.GetComponent<Menubutton>().leftSelectable != null && horizontalAxisAvailable == true && targetSelectable.GetComponent<Menubutton>().leftSelectable.GetComponent<Selectable>().enabled == true)
                {
                    targetSelectable.GetComponent<Menubutton>().leftSelectable.GetComponentInChildren<Selectable>().Select();
                    targetSelectable = targetSelectable.GetComponent<Menubutton>().leftSelectable;
                }

                horizontalAxisAvailable = false;
            }

        }

        if (Input.GetAxisRaw("Horizontal") == 1 && textFieldActive == false)
        {

            if (targetSelectable != null)
            {
                if (targetSelectable.GetComponent<Menubutton>() != null && horizontalAxisAvailable == true)
                {
                    if (targetSelectable.GetComponent<Menubutton>().SelectorBox == true)
                        targetSelectable.GetComponentInParent<OptionScroller>().CycleRight();
                }



                if (targetSelectable.GetComponentInParent<Slider>() != null)
                {
                    targetSelectable.GetComponentInParent<Slider>().value++;
                }

                else if (targetSelectable.GetComponent<Menubutton>().rightSelectable != null && horizontalAxisAvailable == true && targetSelectable.GetComponent<Menubutton>().rightSelectable.GetComponent<Selectable>().enabled == true)
                {
                    targetSelectable.GetComponent<Menubutton>().rightSelectable.GetComponentInChildren<Selectable>().Select();
                    targetSelectable = targetSelectable.GetComponent<Menubutton>().rightSelectable;
                }

                horizontalAxisAvailable = false;
            }
        }

        if (Input.GetButtonDown("Submit") && targetSelectable != null)
        {
            if(targetSelectable.GetComponent<Button>() != null)
            targetSelectable.GetComponent<Button>().onClick.Invoke();
        }

        

    }

    public void PauseGame()
    {
        lastState = "Paused";
        gameActive = false;
        Time.timeScale = 0.0001f;
        gameObject.GetComponent<Menubutton>().OpenPanel();
        gameObject.GetComponent<Menubutton>().EnableButton();
        targetSelectable.GetComponent<Selectable>().Select();
    }

    public void ActivateButton(string buttonName)
    {
        if (GameObject.Find(buttonName).GetComponent<Selectable>() != null)
            GameObject.Find(buttonName).GetComponent<Selectable>().enabled = true;

        if (GameObject.Find(buttonName).GetComponent<Image>() != null)
            GameObject.Find(buttonName).GetComponent<Image>().enabled = true;
        GameObject.Find(buttonName).GetComponentInChildren<Text>().enabled = true;
    }

    public void DisableButton(string buttonName)
    {
        if(GameObject.Find(buttonName).GetComponent<Selectable>() != null)
            GameObject.Find(buttonName).GetComponent<Selectable>().enabled = false;

        if (GameObject.Find(buttonName).GetComponent<Image>() != null)
            GameObject.Find(buttonName).GetComponent<Image>().enabled = false;
        GameObject.Find(buttonName).GetComponentInChildren<Text>().enabled = false;
    }

    public void EndGame(string VictoryOrDefeat)
    {
        GameObject.Find("ScoreController").GetComponent<ScoreController>().canSubmit = true;

        PauseGame();
        GameObject.Find("Settings").GetComponent<Canvas>().enabled = false;
        GameObject.Find("EndLevelScreen").GetComponent<Canvas>().enabled = true;
        targetSelectable = GameObject.Find("EndLevelScreen_defaultselectable");

        if (VictoryOrDefeat == "Victory")
        {
            GameObject.Find("EndLevelTitle").GetComponent<Text>().text = "Level complete!";
        }

        if (VictoryOrDefeat == "Defeat")
        {
            GameObject.Find("EndLevelTitle").GetComponent<Text>().text = "Level failed!";
        }
    }

}

