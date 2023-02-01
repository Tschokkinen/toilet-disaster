using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Controls PoopletMeter behavior.
// Script accessed by TouchControls and MouseControls

public class TummyControls : MonoBehaviour
{
    //private PoopOMeter poopOMeter;
    //public Slider slider;
    private ToiletPaper toiletPaper;

    private PoopletMeter poopletMeter;

    public float doorIntruderSpeed = 0.5f;

    // PART OF OLD GAME MECHANIC
    //public int constipationRelieveSpeed = 1;
    //public bool hasConstipation = false;

    //public int diarrheaRelieveSpeed = 1;
    //public bool hasDiarrhea = false;
    //public bool swiped = false;

    // public float swipeDelaySpeed = 1;
    // END PART OF OLD GAME MECHANIC

    void Start ()
    {
        //poopOMeter = GameObject.Find("Poop-o-meter").GetComponent<PoopOMeter> ();
        //slider = GameObject.Find("Poop-o-meter").GetComponent<Slider> ();
        toiletPaper = GameObject.Find("Toilet paper").GetComponent<ToiletPaper> ();

        //poopletMeter = GameObject.Find("PoopletMeter").GetComponent<PoopletMeter> ();
    }

    /*
    public void MovePooplets ()
    {
        //int speed = 4;
        GameObject[] poopletsInScene = GameObject.FindGameObjectsWithTag("Pooplet");

        foreach (GameObject obj in poopletsInScene)
        {
            Vector3 newPos = new Vector3(obj.transform.position.x + 0.4f, obj.transform.position.y, obj.transform.position.z); 
            obj.transform.position = newPos;
            //obj.transform.position = Vector3.Lerp (obj.transform.position, newPos, Time.deltaTime / speed);
            Debug.Log("Pooplet moved.");
        }
    }
    */


    /* // PART OF OLD GAME MECHANIC
    public void UsedToiletPaper () // Moves Poop-O-Meter towards center by three ints.
    {
        if (poopOMeter.directionLeft == true)
        {
            slider.value = slider.value + 3;
            toiletPaper.greenCircle.SetActive(false);
        }
        else
        {
            slider.value = slider.value - 3;
            toiletPaper.greenCircle.SetActive(false);
        }
    }
    */

    /* // PART OF OLD GAME MECHANIC
    public void MoveMeterCloserToZero () // Was RelieveConstipation
    {
        if (poopOMeter.directionLeft == true)
        {
            slider.value = slider.value + constipationRelieveSpeed;
        }
        else
        {
            slider.value = slider.value - constipationRelieveSpeed;
        }
    }
    */

    /* // PART OF OLD GAME MECHANIC
    public void RelieveDiarrhea ()
    {
        slider.value = slider.value - diarrheaRelieveSpeed;
        swiped = true;
        StartCoroutine(SwipeDelay());
    }
    */

    /*
    public void IntruderEffect (string name)
    {
        if (name == "Mouse")
        {
            
            if (poopOMeter.directionLeft == true)
            {
                slider.value = slider.value - 1;
            }
            else
            {
                slider.value = slider.value + 1;
            }
            
        }
        else if (name == "Spider")
        {
            
            if (poopOMeter.directionLeft == true)
            {
                slider.value = slider.value - 1;
            }
            else
            {
                slider.value = slider.value + 1;
            }
            
        }
        else if (name == "Door")
        {
            StartCoroutine(DoorIntruder());
        }
    }
    */

    /*
    IEnumerator DoorIntruder ()
    {
        while (true)
        {
            yield return new WaitForSeconds(doorIntruderSpeed);

            
            if (poopOMeter.directionLeft == true)
            {
                slider.value = slider.value - 1;
            }
            else
            {
                slider.value = slider.value + 1;
            }
            
        }
    }
    */

    /*
    public void DoorIntruderStop ()
    {
        StopCoroutine(DoorIntruder ());
    }
    */
    
    /*
    public void CallSwipeDelayCoroutine ()
    {
        StartCoroutine(SwipeDelay ());
    }
    */

    // SwipeDelay is used to prevent constant touch recognision when swiping.
    /*
    IEnumerator SwipeDelay ()
    {
        yield return new WaitForSeconds(swipeDelaySpeed);
        swiped = false;
    }
    */
}
