using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIntruders : MonoBehaviour
{
    private DebugMode debugMode;

    public GameObject [] spawnPoints;

    public int miceSpawned = 0;

    public GameObject mouse;
    public GameObject spider;

    private SpriteRenderer spriteRenderer;

    public bool spiderInScene;

    // Start is called before the first frame update
    void Start()
    {
        debugMode = GameObject.Find("Game Controller").GetComponent<DebugMode> ();

        if (debugMode.inDebugMode == true)
        {
            StartCoroutine(SpawnerForSpiders());
        }

        StartCoroutine(SpawnerForMice());

        if (LevelController.levelTwo == true)
        {
            StartCoroutine(SpawnerForSpiders());
        }
    }

    IEnumerator SpawnerForMice () // Spawns mice two at a time.
    {
        while (true)
        {
            GameObject spawnPoint;

            int randomizer = Random.Range(0, 101);

            if (randomizer % 2 == 0)
            {
                spawnPoint = spawnPoints[0];
                spriteRenderer = mouse.GetComponent<SpriteRenderer> ();
                spriteRenderer.flipX = false;
            }
            else
            {
                spawnPoint = spawnPoints[1];
                spriteRenderer = mouse.GetComponent<SpriteRenderer> ();
                spriteRenderer.flipX = true;
            }
            yield return new WaitForSeconds(3);

            if (miceSpawned < 2)
            {
                Instantiate (mouse, spawnPoint.transform.position, Quaternion.identity);
                miceSpawned++; 
            }                
        }
    }

    public void StartSpawningSpiders()
    {
        StartCoroutine(SpawnerForSpiders());
    }

    IEnumerator SpawnerForSpiders ()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            int randomizer = Random.Range(0, 101);

            if (randomizer % 2 == 0 && spiderInScene == false)
            {
                Instantiate (spider, spawnPoints[2].transform.position, Quaternion.identity);
                spiderInScene = true;
            }
            
        }
    }
}
