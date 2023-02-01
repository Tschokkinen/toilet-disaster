using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControls : MonoBehaviour
{
    private AnimationController animationController;
    private Door door;
    private ToiletPaper toiletPaper;
    private LevelStart levelStart;
    private SpawnIntruders spawnIntruders;
    private PoopletMeter poopletMeter;
    private Timer timer;

    public Vector2 startPos;
    public Vector2 direction;

    private GameObject tapHere;
    [SerializeField]private bool firstTouch;

    void Start ()
    {
        animationController = GameObject.Find("Pig").GetComponent<AnimationController> ();
        door = GameObject.Find("Door knob").GetComponent<Door> ();
        toiletPaper = GameObject.Find("TargetAreaForToiletPaper").GetComponent<ToiletPaper> ();
        levelStart = GameObject.Find("Game Controller").GetComponent<LevelStart> ();
        spawnIntruders = GameObject.Find("IntruderSpawnPoints").GetComponent<SpawnIntruders> ();
        poopletMeter = GameObject.Find("PoopletMeter").GetComponent<PoopletMeter> ();
        tapHere = GameObject.Find("TapHere");
    }

    // Update is called once per frame
    void Update ()
    {

        foreach(Touch touch in Input.touches)
        //if (Input.touchCount > 0)
        {
            //Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began) 
            {
                Vector3 ray = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast((Vector2)ray, (Input.GetTouch(0).position));

                if(!firstTouch)
                {
                    tapHere.SetActive(false);
                    firstTouch = true;
                }

                if (hit.collider.gameObject.tag == "Mouse") // Destroys mouse on touch.
                {
                    Debug.Log(hit.collider.name);
                    Destroy(hit.transform.gameObject);
                    spawnIntruders.miceSpawned--;
                    poopletMeter.IntruderEffect("Decrease");
                    animationController.AnimationToIdle(); // Returns pig animation to idle.
                } // End destroy objects on touch.
                else if (hit.collider.gameObject.tag == "Spider") // Destroys spider on touch.
                {
                    Debug.Log(hit.collider.name);
                    Destroy(hit.transform.gameObject);
                    poopletMeter.IntruderEffect("Decrease");
                    spawnIntruders.spiderInScene = false;
                    animationController.AnimationToIdle(); // Returns pig animation to idle.
                }
                else if (hit.collider.gameObject.tag == "Toilet paper" && toiletPaper.greenCircle.activeSelf)
                {
                    Debug.Log(hit.collider.name);
                    poopletMeter.UsedToiletPaper();
                }
                else if (hit.collider.gameObject.tag == "Player" && levelStart.hasStarted == true)
                {
                    poopletMeter.MovePooplets();
                    animationController.StomachPushed();
                }
                else if (hit.collider.gameObject.tag == "Door knob")
                {
                    //Debug.Log("TouchControls: Hit door knob.");
                    door.DoorKnobClick ();
                }
                else if (hit.collider.gameObject.tag == "Boss")
                {
                    Boss bossHit = hit.collider.gameObject.GetComponent<Boss>();
                    Debug.Log("Touch hit boss.");
                    bossHit.BossHit();
                }
            }
        }
    }
}
