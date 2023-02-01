using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private SpawnIntruders spawnIntruders;
    private Door door;
    private Timer timer;
    private BossController bossController;

    public Text score;

    public bool firstBoss = false;
    [SerializeField]private int startBossFightWithPoints = 400;

    [SerializeField]private int poopletsCollected; // Used to count how many pooplets player has "collected".
    [SerializeField]private int totalScore = 0; // Total score.
    public int tempTotal = 0; // Temp score calculated before Coroutine.
    [SerializeField]private int poopletsRequiredForLvlTwo = 20;
    [SerializeField]private int poopletsRequiredForLvlThree = 20;
    [SerializeField]private float pointCounterSpeed = 0.001f; // Determines how fast point counter updates the score.

    void Start()
    {
        spawnIntruders = GameObject.Find("IntruderSpawnPoints").GetComponent<SpawnIntruders>();
        door = GameObject.Find("Door knob").GetComponent<Door>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        score = GameObject.Find("Score").GetComponent<Text>();
        bossController = GameObject.Find("BossController").GetComponent<BossController>();

        StartCoroutine(ScoreUpdater());
    }

    public void Points(int pointsPerPooplet)
    {
        
        poopletsCollected++;

        if(poopletsCollected == poopletsRequiredForLvlTwo) // Triggers level two intruders.
        {
            spawnIntruders.StartSpawningSpiders();
            Debug.Log($"Got {poopletsRequiredForLvlTwo.ToString()} pooplets. Started spawning spiders.");
            timer.GiveMoreTime();
            Debug.Log("Got 20 seconds of extra time.");
        }
        else if(poopletsCollected == poopletsRequiredForLvlThree) // Triggers level three intruders.
        {
            door.StartSpawningDoorIntruders();
            Debug.Log($"Got {poopletsRequiredForLvlThree} pooplets. Started spawning door intruders.");
            timer.GiveMoreTime();
            Debug.Log("Got 20 seconds of extra time.");
        }
        
        tempTotal += pointsPerPooplet; // Increments total score with points gotten from each pooplet.
    }

    void Update()
    {
        if(tempTotal >= startBossFightWithPoints && firstBoss == false) // firstBoss bool used only for testing purposes.
        {
            bossController.StartBossFight();
            firstBoss = true; // Prevents another boss fight from occuring.
        }
    }

    public void UsedPoints(int amount)
    {
        if(tempTotal >= amount)
        {
            tempTotal -= amount;
        }
        else // Not enough points for purchase statement. => => => Work in progress.
        {
            Debug.Log("Not enough points!");
        }
    }
    
    IEnumerator ScoreUpdater() // Updates the score.
    {
        while(true)
        {
            if(totalScore < tempTotal)
            {
                totalScore ++;
                score.text = totalScore.ToString();
                //Debug.Log("ScoreUpdater");
            }
            else if(totalScore > tempTotal)
            {
                totalScore--;
                score.text = totalScore.ToString();
            }
            yield return new WaitForSeconds(pointCounterSpeed);
        }
        
    }


}
