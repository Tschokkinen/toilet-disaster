using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAfterInstantiate : MonoBehaviour
{
    public bool onTarget = false;
    
    public string targetNameTag;

    void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(pos);

        if (onTarget == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Destroying click registered.");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
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
