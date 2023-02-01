using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorKnockGenerator : MonoBehaviour
{
    public Text doorKnock;
    private Timer timer;

    void Start ()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer> ();
        StartCoroutine(Generator());
    }

    IEnumerator Generator()
    {
        yield return new WaitForSeconds(2);
        int number = (Random.Range(0, 6));

        if (number == 4)
        {
            doorKnock.gameObject.SetActive(true);
            timer.timeLeft = timer.timeLeft - 1;
        }
    }

    IEnumerator Pause ()
    {
        StopCoroutine(Generator());
        yield return new WaitForSeconds(3);
        doorKnock.gameObject.SetActive(false);
        StartCoroutine(Generator());
    }
}
