using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button play;

    void Start()
    {
        play.onClick.AddListener(loadScene);
    }

    void loadScene()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {

    }
}
