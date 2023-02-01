using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinners : MonoBehaviour
{
    public GameObject neutralSpin;
    public GameObject panicSpin;
    // Start is called before the first frame update
    void Start()
    {
        NeutralSpin ();
    }

    // Panick
    public void PanickSpin ()
    {
        neutralSpin.SetActive(false);
        panicSpin.SetActive(true);
    }

    // Neutral
    public void NeutralSpin ()
    {
        panicSpin.SetActive(false);
        neutralSpin.SetActive(true);
    }
}
