using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource poopletExits;
    public AudioSource intruderDestroy;


    public void PoopletExits ()
    {
        poopletExits.Play();
    }

    public void IntruderDestroy()
    {
        intruderDestroy.Play();
    }
}
