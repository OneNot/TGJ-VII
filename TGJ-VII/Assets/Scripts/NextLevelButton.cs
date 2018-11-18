using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour {

    GameObject UIController;
    public GameObject NextButton;
    public GameObject PreviousButton;

    // Use this for initialization
    void Start ()
    {
        UIController = GameObject.Find("UIController");
    }
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings -1)
        {
            UIController.GetComponent<UIController>().ActivateButton(gameObject.name);
            NextButton.GetComponent<Menubutton>().previousSelectable = GameObject.Find("NextLevel");
            NextButton.GetComponent<Menubutton>().nextSelectable = GameObject.Find("LevelSelectButton");

            PreviousButton.GetComponent<Menubutton>().previousSelectable = GameObject.Find("LevelSelectButton");
            PreviousButton.GetComponent<Menubutton>().nextSelectable = GameObject.Find("NextLevel");

        }

        else
        {
            UIController.GetComponent<UIController>().DisableButton(gameObject.name);
            NextButton.GetComponent<Menubutton>().previousSelectable = GameObject.Find("QuitGame2");
            NextButton.GetComponent<Menubutton>().nextSelectable = GameObject.Find("LevelSelectButton");

            PreviousButton.GetComponent<Menubutton>().previousSelectable = GameObject.Find("LevelSelectButton");
            PreviousButton.GetComponent<Menubutton>().nextSelectable = GameObject.Find("RestartLevel");
        }


    }
}
