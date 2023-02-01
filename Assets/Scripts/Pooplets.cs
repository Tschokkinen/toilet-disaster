using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooplets : MonoBehaviour
{
    private PoopletDatabase poopletDatabase;

    public List<PoopletConstructor> activePooplets = new List<PoopletConstructor>();

    void Start()
    {
        poopletDatabase = GameObject.Find("PoopletDatabase").GetComponent<PoopletDatabase>();
    }

    public void AddPooplet(string poopletName)
    {
        PoopletConstructor poopletToAdd = poopletDatabase.GetPooplet(poopletName);
        activePooplets.Add(poopletToAdd);
    }

    public int GivePoints(string poopletName)
    {
        PoopletConstructor getValueOf = CheckForItem(poopletName);
        return getValueOf.stats["Value"];
    }

    public PoopletConstructor CheckForItem(string poopletName)
    {
        return activePooplets.Find(poop => poop.Title == poopletName);
    }

    public void RemovePooplet(string poopletName)
    {
        PoopletConstructor poopletToRemove = CheckForItem(poopletName);
        if(poopletToRemove != null)
        {
            activePooplets.Remove(poopletToRemove);
            Debug.Log($"Pooplet removed: {poopletToRemove.Title}");
        }
    }

}
