using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Turns green circle active randomly.
// Controls for toilet paper click when touch controls are not in use.

public class ToiletPaper : MonoBehaviour
{
    private ActivateTouchControls activateTouchControls;
    private PoopletMeter poopletMeter;

    public GameObject greenCircle;

    [SerializeField]private Sprite paperRollFull;
    [SerializeField]private Sprite paperRollEmpty;

    public SpriteRenderer spriteRenderer;

    public float randomizerSpeedInSeconds = 2f;

    // Start is called before the first frame update
    void Start()
    {
        activateTouchControls = GameObject.Find("Game Controller").GetComponent<ActivateTouchControls> ();
        poopletMeter = GameObject.Find("PoopletMeter").GetComponent<PoopletMeter> ();

        spriteRenderer = GameObject.Find("ToiletPaper").GetComponent<SpriteRenderer> ();

        spriteRenderer.sprite = paperRollEmpty;
        
        StartCoroutine(ActivateGreenCircle());
    }

    IEnumerator ActivateGreenCircle () // Activates green circle randomly.
    {
        while (true)
        {
            yield return new WaitForSeconds(randomizerSpeedInSeconds);
            int randomizer = Random.Range(0, 21);

            if (randomizer % 2 == 0 && !greenCircle.activeSelf && poopletMeter.toiletPaperPowerUpActive == false)
            {
                spriteRenderer.sprite = paperRollFull;
                greenCircle.SetActive(true);
            }
        }
    }

    public void ToiletPaperRollToFull ()
    {
        spriteRenderer.sprite = paperRollEmpty;
    }

    void OnMouseOver() // Moves Poop-O-Meter towards center by three ints.
    {
        //Debug.Log("Mouse on toilet paper circle");
        if (!activateTouchControls.useTouchControls)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && greenCircle.activeSelf)
            {
                Debug.Log("Click");
                poopletMeter.UsedToiletPaper();
                greenCircle.SetActive(false);
            }
        }
    }
}
