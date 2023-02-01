using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyObject : MonoBehaviour
{
    # if UNITY_EDITOR_WIN

    private ActivateTouchControls activeTouchControls;
    private AnimationController animationController;
    private SpawnIntruders spawnIntruders;
    private PoopletMeter poopletMeter;

    void Start ()
    {
        activeTouchControls = GameObject.Find("Game Controller").GetComponent<ActivateTouchControls> ();
        animationController = GameObject.Find("Pig").GetComponent<AnimationController> ();
        spawnIntruders = GameObject.Find("IntruderSpawnPoints").GetComponent<SpawnIntruders> ();
        poopletMeter = GameObject.Find("PoopletMeter").GetComponent<PoopletMeter> ();
    }

    void OnMouseOver () // Mouse controls if activateTouchControls == false.
    {
        //Debug.Log("Mouse on ant.");

        if (!activeTouchControls.useTouchControls)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Destroy(gameObject);
                animationController.AnimationToIdle(); // Stops the pig from shaking.
                //spawnIntruders.Remove(gameObject);
                if (gameObject.tag == "Mouse")
                {
                    spawnIntruders.miceSpawned--;

                }
                else if (gameObject.tag == "Spider")
                {
                    spawnIntruders.spiderInScene = false;
                }
                poopletMeter.IntruderEffect("Decrease");
            }
        }
    }

    #endif
}
