using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerUpPanel : MonoBehaviour
{
    public GameObject powerUpPanel;
    public Transform slotPanel;
    public GameObject autoScore; //Used for testing purposes. For actual use, create a list of objects.

    void Start()
    {
        powerUpPanel.SetActive(false);
    }

    public void ActivatePowerUpPanel()
    {
        powerUpPanel.SetActive(true);
        GameObject instance = Instantiate(autoScore); //Used for testing purposes. 
        instance.transform.SetParent(slotPanel);
    }

    public void DeactivatePowerUpPanel()
    {
        powerUpPanel.SetActive(false);
    }
}
