using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPoint : MonoBehaviour
{
    public bool poopletStillOnEnterPoint = false;

    /*
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Pooplet")
        {
            poopletStillOnEnterPoint = true;
        }
    }
    */

    /*
    void OnCollisionExit2D (Collision2D other)
    {
        if (other.gameObject.tag == "Pooplet")
        {
            poopletStillOnEnterPoint = false;
        }
    }
    */

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Pooplet")
        {
            poopletStillOnEnterPoint = true;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Pooplet")
        {
            poopletStillOnEnterPoint = false;
        }
    }

}
