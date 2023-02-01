using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    public bool follow = false;
    public bool onTarget = false;

    public string targetNameTag;

    void OnMouseOver ()
    {
        if (follow == false && Input.GetKeyDown(KeyCode.Mouse0))
        {
            follow = true;
        }
        else if (follow == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (onTarget == true)
            {
                Debug.Log("Destroying click registered.");
                Destroy(gameObject);
            }
            else if (onTarget == false)
            {
                follow = false;
            }
        }
    }

    void Update ()
    {
        if (follow == true)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            transform.position = Camera.main.ScreenToWorldPoint(pos);
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        Debug.Log("Collided");

        if (other.gameObject.tag == targetNameTag)
        {
            onTarget = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == targetNameTag)
        {
            onTarget = false;
        }
    }
}
