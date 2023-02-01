using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour
{
    //private PoopOMeter poopOMeter;
    //private LevelStart levelStart;

    //public Button constipationDebugButton;
    //public Button diarrheaDebugButton;

    //public GameObject debugMode;
    public bool inDebugMode = false;
    //public bool modeSelected = false;
    

    /*
    void Awake ()
    {
        if (inDebugMode == true)
        {
            Time.timeScale = 0;
            //debugMode.SetActive(true);

            poopOMeter = GameObject.Find("Poop-o-meter").GetComponent<PoopOMeter> ();
            levelStart = GameObject.Find("Game Controller").GetComponent<LevelStart> ();

            //constipationDebugButton.onClick.AddListener(SelectMode);
            //diarrheaDebugButton.onClick.AddListener(SelectModeTwo);
        }
    }
    */

    /*
    void SelectMode ()
    {
        //poopOMeter.DebugModePoopType(1);
        debugMode.SetActive(false);
        modeSelected = true;
        levelStart.LevelStartDelayCoroutine ();
        Debug.Log("Alpha1");
    }
    */

    /*
    void SelectModeTwo ()
    {
        //poopOMeter.DebugModePoopType(2);
        debugMode.SetActive(false);
        modeSelected = true;
        levelStart.LevelStartDelayCoroutine ();
        Debug.Log("Alpha2");
    }
    */

    /*
    void Update ()
    {
        if (modeSelected == false && Input.GetKey(KeyCode.Alpha1))
        {
            //poopOMeter.DebugModePoopType(1);
            debugMode.SetActive(false);
            Time.timeScale = 1;
            modeSelected = true;
            Debug.Log("Alpha1");
        }
        else if (modeSelected == false && Input.GetKey(KeyCode.Alpha2))
        {
            //poopOMeter.DebugModePoopType(2);
            debugMode.SetActive(false);
            Time.timeScale = 1;
            modeSelected = true;
            Debug.Log("Alpha2");
        }
    }
    */
    
}
