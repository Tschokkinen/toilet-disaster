using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaperRoll : MonoBehaviour
{
    public GameObject toiletPaper;

    void OnMouseOver ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(toiletPaper, transform.position, Quaternion.identity);
        }
    }
}
