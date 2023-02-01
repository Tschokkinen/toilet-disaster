using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public Button reloadSceneButton;

    // Start is called before the first frame update
    void Start()
    {
        reloadSceneButton.onClick.AddListener(Reload);
    }

    // Update is called once per frame
    void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


}
