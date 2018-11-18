using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSelectedLevel : MonoBehaviour
{

    public GameObject LevelSelector;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartLevel()
    {
        gameObject.GetComponent<Menubutton>().SceneName = LevelSelector.GetComponent<OptionScroller>().selectedOption;
        gameObject.GetComponent<Menubutton>().StartScene();
        GameObject.Find("UIController").GetComponent<UIController>().gameActive = true;
    }
}