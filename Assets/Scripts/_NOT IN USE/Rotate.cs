using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool rotateCW = false;
    public bool ignoreTimescale = false;

    // Update is called once per frame
    void Update()
    {
        if (!rotateCW && ignoreTimescale == false)
        {
            transform.Rotate (0, 0, 50 * Time.deltaTime);
        }
        else if (rotateCW && ignoreTimescale == false)
        {
            transform.Rotate (0, 0, -50 * Time.deltaTime);
        }
        else if (!rotateCW && ignoreTimescale == true)
        {
            transform.Rotate (0, 0, 50 * Time.unscaledDeltaTime);
        }
        else if (rotateCW && ignoreTimescale == true)
        {
            transform.Rotate (0, 0, -50 * Time.unscaledDeltaTime);
        }
    }

}
