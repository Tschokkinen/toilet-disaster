using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePig : MonoBehaviour
{
    public bool shakeStarted = false;

    public void StartShake ()
    {
        if (shakeStarted == false)
        {
            StartCoroutine(Shake());
            //shakeStarted = true;
        }
    }

    IEnumerator Shake ()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            float shakeAmount = Random.Range(-4.0f, 4.0f);
            transform.Rotate(0.0f, 0.0f, shakeAmount);
        }
    }

}
