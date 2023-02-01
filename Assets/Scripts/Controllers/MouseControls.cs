using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// This script features mouse controls for tummy push and swipe.
// On "Stomach touch area" gameobject.

public class MouseControls : MonoBehaviour
{
    #if UNITY_EDITOR_WIN

    private AnimationController animationController;
    private TummyControls tummyControls;
    private ActivateTouchControls activateTouchControls;
    private LevelStart levelStart;
    private PoopletMeter poopletMeter;

    private GameObject tapHere;
    [SerializeField]private bool firstTouch;

    void Start ()
    {
        animationController = GameObject.Find("Pig").GetComponent<AnimationController> ();
        activateTouchControls = GameObject.Find("Game Controller").GetComponent<ActivateTouchControls> ();
        levelStart = GameObject.Find("Game Controller").GetComponent<LevelStart> ();
        poopletMeter = GameObject.Find("PoopletMeter").GetComponent<PoopletMeter> ();

        tapHere = GameObject.Find("TapHere");
    }

    void OnMouseOver () // Controls used if touch controls aren't actived from ActivateTouchControls script.
    {
        if (!activateTouchControls.useTouchControls)
        {
            //Debug.Log("Mouse on stomach");
            if (Input.GetKeyDown(KeyCode.Mouse0) && levelStart.hasStarted == true)
            {
                if (!firstTouch)
                {
                    tapHere.SetActive(false);
                    firstTouch = true;
                }

                animationController.StomachPushed();
                poopletMeter.MovePooplets();
                //animationController.AnimationToIdle();
            }
        }
    }

    #endif
}
