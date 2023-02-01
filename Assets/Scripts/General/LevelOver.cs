using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOver : MonoBehaviour
{
    public Button reloadScene;
    public GameObject reloadScenePanel;

    private Timer timer;
    private LevelStart levelStart;

    public Text levelOverText;
    //public GameObject success;
    //public GameObject fail;

    public GameObject[] activeInScene;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer> ();
        levelStart = GameObject.Find("Game Controller").GetComponent<LevelStart> ();
    }

    public void WinConditions ()
    {
        levelStart.hasStarted = false;

        reloadScene.gameObject.SetActive(true);
        reloadScenePanel.SetActive(true);
        //LevelController.levelCounter++;

        /*
        if (LevelController.levelTwo == false)
        {
            LevelController.levelTwo = true;
            Debug.Log("Level two");
        }
        else if (LevelController.levelThree == false)
        {
            LevelController.levelThree = true;
            LevelController.levelTwo = false;
            Debug.Log("Level three");
        }
        else if (LevelController.levelThree == false)
        {
            LevelController.levelFour = true;
            LevelController.levelThree = false;
            Debug.Log("Level four");
        }
        else if (LevelController.levelFour == true && LevelController.levelCounter == 4)
        {
            Application.Quit();
        }
        */
        
        Time.timeScale = 0;
        
    }

}