using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public int ignoreLayerOne;
    public int ignoreLayerTwo;

    void Start()
    {
        Physics2D.IgnoreLayerCollision (ignoreLayerOne, ignoreLayerTwo, true);
    }
}
