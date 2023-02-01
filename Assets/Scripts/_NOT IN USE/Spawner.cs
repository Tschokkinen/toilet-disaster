using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPointLeft;
    public GameObject spawnPointRight;
    private SpriteRenderer spriteRenderer;

    // The GameObject to instantiate.
    public GameObject entityToSpawn;

    // An instance of the ScriptableObject defined above.
    public SpawnManagerScriptableObject spawnManagerValues;

    // This will be appended to the name of the created entities and increment when each is created.
    int instanceNumber = 1;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn () // Spawns ants like there's no tomorrow.
    {
        //int currentSpawnPointIndex = 0;

        Debug.Log("Spawn started");

        while (true)
        {
            GameObject spawnPoint;
            int randomizer = Random.Range(1, 100);

            if (randomizer % 2 == 0)
            {
                spawnPoint = spawnManagerValues.spawnPoints[0];
                spriteRenderer = entityToSpawn.GetComponent<SpriteRenderer> ();
                spriteRenderer.flipX = false;
            }
            else
            {
                spawnPoint = spawnManagerValues.spawnPoints[1];
                spriteRenderer = entityToSpawn.GetComponent<SpriteRenderer> ();
                spriteRenderer.flipX = true;
            }
            instanceNumber++;
            yield return new WaitForSeconds(3);
            GameObject currentEntity = Instantiate (entityToSpawn, spawnPoint.transform.position, Quaternion.identity);
            currentEntity.name = spawnManagerValues.prefabName + instanceNumber;
        }
    }
}