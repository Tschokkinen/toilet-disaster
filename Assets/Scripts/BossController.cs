using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public List<GameObject> bossEnterPoints = new List<GameObject>();
    [SerializeField]private GameObject boss;
    [SerializeField]private GameObject rainbow;

    public void StartBossFight()
    {
        int startPoint = Random.Range(0,3);
        Instantiate(boss, bossEnterPoints[startPoint].transform.position, Quaternion.identity);
        rainbow.SetActive(true);
    }

    public void DeactivateRainbow() => rainbow.SetActive(false);
}
