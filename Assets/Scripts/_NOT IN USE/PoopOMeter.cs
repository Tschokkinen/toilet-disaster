using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopOMeter : MonoBehaviour
{
    //private DebugMode debugMode; // DebugMode script.
    //public int stomachStateDebug; // Used only in debug mode.

    private LevelOver levelOver; // LevelOver script.
    //private Spinners spinners; // Spinner showing game state.

    //public Text stomachState; //Displays stomach state during gameplay. A text object in canvas under Poop-O-Meter.

    private TummyControls tummyControls; // Mouse controls for tummy.
    public Slider slider; // Poop-O-Meter slider.
    public Text sliderText; // Poop-O-Meter slider text.

    public int sliderStartValue = 0; // Start value for Poop-O-Meter.

    int randomizeNumber;
    //public int meterDirection;
    public bool directionLeft;

    [HideInInspector]public int constipationSpeed = 1; // Determines how many units the slider moves everytime the IEnumerator runs.
    public bool constipated = false; // Player has constipation.
    public float constipationInterval; // Determines how often the IEnumerator runs.

    [HideInInspector]public int diarrheaSpeed = 1; // Determines how many units the slider moves everytime the IEnumerator runs.
    public bool diarrhead = false; // Player has diarrhea.
    public float diarrheaInterval; // Determines how often the IEnumerator runs.

    public bool gameOver = false;


    void Awake()
    {
        //debugMode = GameObject.Find("Game Controller").GetComponent<DebugMode> ();
        //stomachState = GameObject.Find("Stomach state").GetComponent<Text> ();
        //tummyControls = GameObject.Find("Game Controller").GetComponent<TummyControls> ();
        levelOver = GameObject.Find("Game Controller").GetComponent<LevelOver> ();
        //spinners = GameObject.Find("Spinner Area").GetComponent<Spinners> ();

        slider = GetComponent<Slider> ();
        slider.value = sliderStartValue;
    }

    // Start is called before the first frame update
    void Start ()
    {
        randomizeNumber = Random.Range(0, 101);

        if (randomizeNumber % 2 == 0)
        {
            directionLeft = true;
        }
        else
        {
            directionLeft = false;

        }

        //StartCoroutine(Constipation());
        StartCoroutine(RandomizeMeterDirection());
        // If debugMode is not active (activate a bool from Game Controller),
        // this randomizer chooses either constipation or diarrhea as a stomach type.
        /*
        if (debugMode.inDebugMode == false)
        {
            int randomizer = Random.Range(1, 100);

            if (randomizer % 2 == 0)
            {
                PoopType(1); // Constipation
            }
            else if (randomizer % 2 == 1)
            {
                PoopType(2); // Diarrhea
            }
        }
        */

        //PoopType(1);
    }

    void Update ()
    {
        //sliderText.text = "Poop-O-Meter: " + slider.value.ToString(); // Updates the slider value in UI.

        /*
        if (slider.value > 10 || slider.value < -10)
        {
            spinners.PanickSpin ();
        }
        else
        {
            spinners.NeutralSpin ();
        }
        */

        // Determines lose conditions if Poop-O-Meter reaches either extreme.
        /*
        if (slider.value == 20 && gameOver == false)
        {
            levelOver.LoseConditions(1);
            gameOver = true;
        }
        else if (slider.value == -20 && gameOver == false)
        {
            levelOver.LoseConditions(2);
            gameOver = true;
        }
        */
    }

    // Called by DebugMode script.
    /*
    public void DebugModePoopType(int selected)
    {
        PoopType(selected);
    }
    */

    // Determines stomach type: diarrhea or constipation.
    public void PoopType (int _idx)
    {
        switch (_idx)
        {
            /*
            case 0: // Case 0 Normal is not in use.
                Debug.Log("Case 0: Normal");
                stomachState.text = stomachState.text + "normal.";
                sliderText.text = "Poop-O-Meter: " + slider.value.ToString();
            break;
            */

            case 1: // Constipation
                //Debug.Log("Case 1: Constipated");
                constipated = true;
                //tummyControls.hasConstipation = true;
                //stomachState.text = stomachState.text + "constipation. Tap stomach!";
                sliderText.text = "Poop-O-Meter: " + slider.value.ToString();
                //constipationInterval = Random.Range(1, 4); // Used for randomizing Poop-O-Meter pointer speed.
                //StartCoroutine(Constipation());
            break;

            /*
            case 2: // Diarrhea
                Debug.Log("Case 2: Diarrhea");
                diarrhead = true;
                tummyControls.hasDiarrhea = true;
                //stomachState.text = stomachState.text + "diarrhea. Swipe stomach!";
                sliderText.text = "Poop-O-Meter: " + slider.value.ToString();
                //diarrheaInterval = Random.Range(1, 4); // Used for randomizing Poop-O-Meter pointer speed.
                StartCoroutine(Diarrhea());
            break;
            */
        }
    }

    // Slider controller for constipation (Poop-O-Meter)
    /*
    IEnumerator Constipation ()
    {
        constipated = true;
        tummyControls.hasConstipation = true;

        while (constipated == true)
        {
            yield return new WaitForSeconds(constipationInterval);

            if (directionLeft == true)
            {
                slider.value = slider.value - 1;
            }
            else
            {
                slider.value = slider.value + 1;
            }
            
            sliderText.text = "Poop-O-Meter: " + slider.value.ToString();
        }
    }
    */

    IEnumerator RandomizeMeterDirection ()
    {
        while (true)
        {
            randomizeNumber = Random.Range(0, 101);
            yield return new WaitForSeconds(2);
            if (randomizeNumber % 2 == 0)
            {
                //meterDirection = -1;
                directionLeft = true;
            }
            else
            {
                //meterDirection = 1;
                directionLeft = false;
            }
        }
    }

    // Slider controller for diarrhea (Poop-O-Meter)
    /*
    IEnumerator Diarrhea ()
    {
        while (diarrhead == true)
        {
            yield return new WaitForSeconds(diarrheaInterval);
            slider.value = slider.value + diarrheaSpeed;
            sliderText.text = "Poop-O-Meter: " + slider.value.ToString();
        }
    }
    */
}
