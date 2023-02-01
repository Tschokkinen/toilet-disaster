using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public ActivateTouchControls activateTouchControls;
    private AnimationController animationController;
    private PoopletMeter poopletMeter;
    private DebugMode debugMode;

    public GameObject redCirlcle;
    public int requiredTapCount = 3;
    public int tapCount = 0;
    public Vector3 scaleDownValue = new Vector3 (-0.2f, -0.2f, -0.2f);
    public Vector3 scaleStartValue = new Vector3 (1.0f, 1.0f, 1.0f);

    public float randomizerSpeedInSeconds = 2f;

    // Start is called before the first frame update
    void Start()
    {
        tapCount = 0;

        activateTouchControls = GameObject.Find("Game Controller").GetComponent<ActivateTouchControls> ();
        animationController = GameObject.Find("Pig").GetComponent<AnimationController> ();
        poopletMeter = GameObject.Find("PoopletMeter").GetComponent<PoopletMeter> ();
        debugMode = GameObject.Find("Game Controller").GetComponent<DebugMode> ();

        if (LevelController.levelThree == true)
        {
            StartCoroutine(ActivateRedCircle());
        }

        if (debugMode.inDebugMode == true)
        {
            StartCoroutine(ActivateRedCircle()); // Used for debuggin purposes only.
        }
    }

    public void StartSpawningDoorIntruders()
    {
        StartCoroutine(ActivateRedCircle());
    }

    IEnumerator ActivateRedCircle ()
    {
        while (true)
        {
            yield return new WaitForSeconds(randomizerSpeedInSeconds);
            int randomizer = Random.Range(0, 21);

            if (randomizer % 2 == 0 && !redCirlcle.activeSelf)
            {
                redCirlcle.SetActive(true);
                // CALL IntruderEffect HERE
                //tummyControls.IntruderEffect("Door");
                poopletMeter.IntruderEffect("Increase");
                animationController.MouseTouchingFeet();
            }
        }
    }

    public void DoorKnobClick () // Deactives red circle.
    {
        tapCount++;
        redCirlcle.transform.localScale = redCirlcle.transform.localScale + scaleDownValue;

        if (tapCount == requiredTapCount)
        {
            poopletMeter.IntruderEffect("Decrease");
            redCirlcle.transform.localScale = scaleStartValue;
            redCirlcle.SetActive(false);
            tapCount = 0;
        }
    }

    // Used only with mouse controls.
    void OnMouseOver ()
    {
        //Debug.Log("Mouse on door knob circle");
        if (!activateTouchControls.useTouchControls)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && redCirlcle.activeSelf == true)
            {
                //Debug.Log("Click");
                DoorKnobClick ();
            }
        }
    }
    // End

}
