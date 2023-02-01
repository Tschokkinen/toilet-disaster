using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public GameObject go;
    public bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Current level: " + LevelController.levelCounter);
        StartCoroutine(LevelStartDelay());
    }

    public void LevelStartDelayCoroutine ()
    {
        StartCoroutine(LevelStartDelay ());
    }

    IEnumerator LevelStartDelay ()
    {
        go.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        go.SetActive(false);
        hasStarted = true;
        Time.timeScale = 1;
    }
}
