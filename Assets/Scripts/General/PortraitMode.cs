using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait; // Forces screen in portrait orientation.
    }
}
