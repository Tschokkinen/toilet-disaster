using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private BossController bossController;

    public List<GameObject> bossEnterPoints = new List<GameObject>();
    public bool changePos = true;
    public int bossHitsRequired = 4;
    public int bossHits = 0;

    void Start()
    {
        bossController = GameObject.Find("BossController").GetComponent<BossController>();
        StartCoroutine(BossFight());
    }

    IEnumerator BossFight()
    {
        while(true)
        {
            if(changePos == true)
            {
                int idx = Random.Range(0,3);

                gameObject.transform.position = bossEnterPoints[idx].transform.position;
                //Debug.Log("Changed boss position");
                changePos = false;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void BossHit()
    {
        changePos = true;
        bossHits++;
        gameObject.transform.position = bossEnterPoints[3].transform.position; // Hides boss momentarily.

        if(bossHits == bossHitsRequired)
        {
            bossController.DeactivateRainbow();
            Destroy(gameObject);
        }
    }

    void OnMouseOver() // Used only for mouse controls.
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log("Clicked boss.");
            BossHit();
        }
    }
}
