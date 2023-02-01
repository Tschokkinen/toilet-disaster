using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopletDatabase : MonoBehaviour
{
    public List<PoopletConstructor> poops = new List<PoopletConstructor>();

    void Awake()
    {
        BuildDatabase();
    }

    public PoopletConstructor GetPooplet (string itemName)
    {
        return poops.Find(poop => poop.Title == itemName);
    }

    public void BuildDatabase()
    {
        poops = new List<PoopletConstructor>()
            {
                new PoopletConstructor(0, "Normal Pooplet",
                new Dictionary<string, int>
                {
                    {"Value", 200}
                })
            };
    }
}
