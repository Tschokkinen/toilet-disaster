using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScreen : MonoBehaviour
{
    private ActivateTouchControls activateTouchControls;

    void Start ()
    {
        activateTouchControls = GameObject.Find("Game Controller").GetComponent<ActivateTouchControls> ();
    }

    void Update ()
    {
        if (!activateTouchControls.useTouchControls) // Mouse input for SelectScreen.
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SceneManager.LoadScene("LevelOne");
            }
        }
        else // Touch controls for SelectScreen.
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    SceneManager.LoadScene("LevelOne");
                }
            }
        }
    }
}
