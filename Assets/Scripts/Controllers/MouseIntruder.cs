using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseIntruder : MonoBehaviour
{
    private AnimationController animationController;
    private PoopletMeter poopletMeter;

    public Vector3 leftTarget;
    public Vector3 rightTarget;
    public Vector3 targetPosition;

    private SpriteRenderer spriteRenderer;

    public Vector3 retreatPosition;
    public bool retreat = false;

    public bool stopMouse = false;

    public int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        leftTarget = new Vector3(-5.0f, transform.position.y, transform.position.z);
        rightTarget = new Vector3(5.0f, transform.position.y, transform.position.z);

        spriteRenderer = GetComponent<SpriteRenderer> ();

        if (transform.position.x < 1.0)
        {
            spriteRenderer.flipX = true;
            targetPosition = rightTarget;
        }
        else
        {
            spriteRenderer.flipX = false;
            targetPosition = leftTarget;
        }

        animationController = GameObject.Find("Pig").GetComponent<AnimationController> ();
        poopletMeter = GameObject.Find("PoopletMeter").GetComponent<PoopletMeter> ();
        StartCoroutine(MoveToTarget());
        
        poopletMeter.IntruderEffect("Increase");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Target area")
        {
            //Debug.Log("Entered target area");
            animationController.MouseTouchingFeet();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Target area")
        {
            //Debug.Log("Exited target area.");
            animationController.AnimationToIdle();
        }
    }

    void OnCollisionEnter2D (Collision2D other) // Turn the mouse around.
    {
        if (other.collider.gameObject.tag == "Mouse destroy") // Tag name from old mechanic -> Doesn't destroy anymore. Change tag when you have time.
        {

            if (transform.position.x < 1.0)
            {
                spriteRenderer.flipX = true;
                targetPosition = rightTarget;
            }
            else
            {
                spriteRenderer.flipX = false;
                targetPosition = leftTarget;
            }
        }
    }

    public void StopMoveToTarget ()
    {
        StopCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget ()
    {
        while (stopMouse == false)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / speed);
            //time += Time.deltaTime;
            yield return null;
        }
    }

}
