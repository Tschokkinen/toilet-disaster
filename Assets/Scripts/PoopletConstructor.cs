using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoopletConstructor
{
    public int Id { get; set; }
    public string Title { get; set; } //Used for connecting the right object instance with the instantiated prefab.
    public Dictionary<string, int> stats = new Dictionary<string, int>(); // Includes a key "Points" and a value.
    //public GameObject go; // Prefab in resources folder. -> Different than the prefab in prefabs folder.

    public PoopletConstructor(int id, string title, Dictionary<string, int> stats)
    {
        this.Id = id;
        this.Title = title;
        this.stats = stats;
        //this.go = Resources.Load<GameObject>("Prefabs/Pooplets/" + type);
    }

}
