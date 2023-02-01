using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoScore : MonoBehaviour, IPointerClickHandler
{
    PoopletMeter poopletMeter;
    PowerUpPanel powerUpPanel;

    void Start()
    {
        poopletMeter = GameObject.Find("PoopletMeter").GetComponent<PoopletMeter>();
        powerUpPanel = GameObject.Find("Canvas").GetComponent<PowerUpPanel>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("AutoScore clicked.");
        poopletMeter.AutoMovePoopletsStart();
        powerUpPanel.DeactivatePowerUpPanel();
    }
}
