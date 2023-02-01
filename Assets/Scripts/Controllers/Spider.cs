using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    //private TummyControls tummyControls;
    private PoopletMeter poopletMeter;

    public float swingSpeed = 1.0f;
    public float negativeAngleZ = -40;
    public float positiveAngleZ = 40;
 
    void Start ()
    {
        //tummyControls = GameObject.Find("Game Controller").GetComponent<TummyControls> ();
        poopletMeter = GameObject.Find("PoopletMeter").GetComponent<PoopletMeter> ();
        poopletMeter.IntruderEffect("Increase");
    }

    // Makes the spider swing back and forth
    void Update ()
    {
        float z = Mathf.SmoothStep(negativeAngleZ, positiveAngleZ, Mathf.PingPong(swingSpeed * Time.time, 1));
        transform.rotation = Quaternion.Euler(0, 0, z);
    }

    /*
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Head")
        {
            Debug.Log("Hit head");
            //tummyControls.IntruderEffect("Spider");
            poopletMeter.IntruderEffect("Increase");
        }
    }
    */
}
