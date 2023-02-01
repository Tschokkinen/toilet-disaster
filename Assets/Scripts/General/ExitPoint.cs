using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ExitPoint : MonoBehaviour
{
    private Pooplets pooplets;
    private PointCounter pointCounter;
    private AudioManager audioManager;

    public Text amountOfPooplets;
    public int amount;
    //public int howManyPoints;

    void Start ()
    {
        pooplets = GameObject.Find("Pooplets").GetComponent<Pooplets>();
        pointCounter = GameObject.Find("Game Controller").GetComponent<PointCounter>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Pooplet")
        {
            string poopletName = other.gameObject.name;
            int howManyPoints = pooplets.GivePoints(poopletName);
            Debug.Log($"ExitPoints script => PoopletName: {poopletName}");
            pooplets.RemovePooplet(poopletName);

            Destroy(other.gameObject);
            Debug.Log($"Destroyed gameObject: {other.gameObject.name}");
            audioManager.PoopletExits();
            amount++;
            amountOfPooplets.text = amount.ToString();
            pointCounter.Points(howManyPoints);
        }
    }
}