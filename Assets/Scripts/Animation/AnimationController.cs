using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator> ();
    }

    public void MouseTouchingFeet ()
    {
        anim.SetTrigger("Mouse touch");
    }

    public void AnimationToIdle ()
    {
        anim.SetTrigger("Idle");
    }

    public void StomachPushed ()
    {
        anim.SetTrigger("Stomach pushed");
        AnimationToIdle();
    }

    public void StomachSwipe ()
    {
            anim.SetTrigger("Stomach swipe");
    }

    /*
    public void StomachSwipeReset ()
    {
        anim.ResetTrigger("Stomach swipe");
    }
    */
}
