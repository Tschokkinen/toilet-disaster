using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopletMeter : MonoBehaviour
{
    private PoopletDatabase poopletDatabase;
    private Pooplets pooplets;
    private ToiletPaper toiletPaper;
    private Timer timer;
    private ExitPoint exitPoint;
    private AudioManager audioManager;

    public List<GameObject> poopletPrefabs = new List<GameObject> ();

    public GameObject enterPoint; // Pooplet enter point.
    private EnterPoint enterPointScript; // Script attached to EnterPoint game object.

    public float doorIntruderSpeed = 0.5f;

    // PoopletMeter values
    [SerializeField]private float activePoopletTapValue = 0.4f;
    public float defaultTapValue = 0.4f;
    public float intruderTapValue = 0.03f;
    public float toiletPaperTapValue = 0.05f;
    [SerializeField]private float toiletPaperPowerUp = 5;
    [SerializeField]private float spawnSpeedMin = 2.0f;
    [SerializeField]private float spawnSpeedMax = 6.0f;
    public bool toiletPaperPowerUpActive;

    Coroutine startGeneratingPooplets;

    [SerializeField]private bool autoScoreInUse;

    // Start is called before the first frame update
    void Start()
    {
        poopletDatabase = GameObject.Find("PoopletDatabase").GetComponent<PoopletDatabase>();
        pooplets = GameObject.Find("Pooplets").GetComponent<Pooplets>();
        toiletPaper = GameObject.Find("TargetAreaForToiletPaper").GetComponent<ToiletPaper> ();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        exitPoint = GameObject.Find("ExitPoint").GetComponent<ExitPoint>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        startGeneratingPooplets = StartCoroutine(GeneratePooplets());
        enterPointScript = enterPoint.GetComponent<EnterPoint> ();
    }

    IEnumerator GeneratePooplets ()
    {
        while (true)
        {
            float instantiationSpeed = Random.Range(spawnSpeedMin,spawnSpeedMax);

            yield return new WaitForSeconds(instantiationSpeed);

            if (enterPointScript.poopletStillOnEnterPoint == false)
            {  
                // Currently only one type of pooplet is being used.
                GameObject instance = Instantiate(poopletPrefabs[0], enterPoint.transform.position, Quaternion.identity);
                instance.name = poopletPrefabs[0].name;
                Debug.Log("Instance.name: " + instance.name);
                pooplets.AddPooplet(instance.name);
            }
        }
    }

    public void MovePooplets ()
    {
        if(!autoScoreInUse)
        {
            GameObject[] poopletsInScene = GameObject.FindGameObjectsWithTag("Pooplet");

            foreach (GameObject obj in poopletsInScene)
            {
                Vector3 newPos = new Vector3(obj.transform.position.x + activePoopletTapValue, obj.transform.position.y, obj.transform.position.z); 
                obj.transform.position = newPos;
                //Debug.Log("Pooplet moved.");
            }
        }
    }

    public void AutoMovePoopletsStart()
    {
        StartCoroutine(AutoMovePooplets());
    }

    IEnumerator AutoMovePooplets()
    {
        autoScoreInUse = true;
        int targetValueOfPooplets = exitPoint.amount + 5; // Max amount of pooplets moved to exit.

        while(targetValueOfPooplets > exitPoint.amount)
        {
            GameObject[] poopletsInScene = GameObject.FindGameObjectsWithTag("Pooplet");
            
            foreach (GameObject obj in poopletsInScene)
            {
                Vector3 newPos = new Vector3(obj.transform.position.x + activePoopletTapValue, obj.transform.position.y, obj.transform.position.z); 
                obj.transform.position = newPos;
            }
            yield return new WaitForSeconds(0.1f);
        }

        autoScoreInUse = false;
    }

    public void UsedToiletPaper ()
    {
        //Debug.Log("Used toilet paper for boost.");
        toiletPaper.greenCircle.gameObject.SetActive(false);
        toiletPaper.ToiletPaperRollToFull();
        StartCoroutine(ToiletPaperTimer());
    }

    IEnumerator ToiletPaperTimer ()
    {
        //Debug.Log("Toilet paper timer");
        toiletPaperPowerUpActive = true;
        activePoopletTapValue = activePoopletTapValue + toiletPaperTapValue;
        yield return new WaitForSeconds(toiletPaperPowerUp);
        activePoopletTapValue = activePoopletTapValue - toiletPaperTapValue;
        toiletPaperPowerUpActive = false;
    }

    // Use "Decrease" parameter to lower intruderAmount and "Increase" to do the opposite.
    public void IntruderEffect (string name)
    {
        if (name == "Decrease")
        {
            activePoopletTapValue = activePoopletTapValue + intruderTapValue;
            timer.TimeFromDefeatedIntruders();
            audioManager.IntruderDestroy();
        }
        else if (name == "Increase")
        {
            activePoopletTapValue = activePoopletTapValue - intruderTapValue;
        }
    }
}
