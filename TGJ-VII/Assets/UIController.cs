using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIController : MonoBehaviour
{
    bool verticalAxisAvailable;
    bool horizontalAxisAvailable;

    public GameObject targetSelectable;

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();

        targetSelectable = GameObject.Find("Mainmenu_defaultselectable");
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Vertical") == 0)
            verticalAxisAvailable = true;

        if (Input.GetAxis("Horizontal") == 0)
            horizontalAxisAvailable = true;



        if (Input.GetAxisRaw("Vertical") == -1 && verticalAxisAvailable == true)
        {
            verticalAxisAvailable = false;

            if (targetSelectable.GetComponent<Menubutton>().nextSelectable != null)
            {
                targetSelectable.GetComponent<Menubutton>().nextSelectable.GetComponentInChildren<Selectable>().Select();
                targetSelectable = targetSelectable.GetComponent<Menubutton>().nextSelectable;
            }

        }

        if (Input.GetAxisRaw("Vertical") == 1 && verticalAxisAvailable == true)
        {
            verticalAxisAvailable = false;

            if (targetSelectable.GetComponent<Menubutton>().previousSelectable != null)
            {
                targetSelectable.GetComponent<Menubutton>().previousSelectable.GetComponentInChildren<Selectable>().Select();
                targetSelectable = targetSelectable.GetComponent<Menubutton>().previousSelectable;
            }

        }

        if (Input.GetAxisRaw("Horizontal") == -1 && verticalAxisAvailable == true)
        {
            verticalAxisAvailable = false;

            if (targetSelectable.GetComponentInParent<Slider>() != null)
            {
                targetSelectable.GetComponentInParent<Slider>().value--;
            }

        }

        if (Input.GetAxisRaw("Horizontal") == 1 && verticalAxisAvailable == true)
        {
            verticalAxisAvailable = false;

            if (targetSelectable.GetComponentInParent<Slider>() != null)
            {
                targetSelectable.GetComponentInParent<Slider>().value++;
            }

        }

        if (Input.GetButton("Submit"))
        {
            if(targetSelectable.GetComponent<Button>() != null)
            targetSelectable.GetComponent<Button>().onClick.Invoke();
        }

        

    }

}

