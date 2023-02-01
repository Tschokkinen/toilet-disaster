using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    private PointCounter pointCounter;
    private PowerUpPanel powerUpPanel;

    public GameObject store;
    public Button autoScore;
    public Button openStore;
    public bool disableStore = false;

    public bool isPaused; // Used to tell timer and intruders and generator to stop momentarily.

    // Start is called before the first frame update
    void Start()
    {
        pointCounter = GameObject.Find("Game Controller").GetComponent<PointCounter>();
        powerUpPanel = GameObject.Find("Canvas").GetComponent<PowerUpPanel>();

        openStore.onClick.AddListener(delegate{ButtonManager(0);});
        autoScore.onClick.AddListener(delegate{ButtonManager(1);});

        openStore.gameObject.SetActive(false);
    }

    void Update()
    {
        if(pointCounter.tempTotal > 200 && disableStore == false)
        {
            openStore.gameObject.SetActive(true);
        }
    }

    void OpenStore()
    {
        isPaused = true;
        store.SetActive(true);
        Time.timeScale = 0;
    }

    void ButtonManager(int idx)
    {
        switch (idx)
        {
            case 0:
                OpenStore();
            break;

            case 1:
                Debug.Log("Purchased AutoScore");
                HasEnoughpoints(200);
            break;
        }
    }

    void HasEnoughpoints(int amount)
    {
        if(pointCounter.tempTotal >= amount)
        {
            pointCounter.UsedPoints(amount);
            store.SetActive(false);
            isPaused = true;
            Time.timeScale = 1;
            powerUpPanel.ActivatePowerUpPanel();
        }
        else
        {
            Debug.Log("The computer says no");
            store.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
