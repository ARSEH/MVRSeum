using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSoundController : MonoBehaviour
{
    public static MenuSoundController _instance;
    void Awake()
    {

        if (MenuSoundController._instance == null)
        {
            Debug.Log("soy nullo");
            MenuSoundController._instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Debug.Log("He entrado aquí");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Game")
        {
            Debug.Log("Estoy en la scena Game");
            // Destroy(gameObject);
            Destroy(_instance.gameObject);
            MenuSoundController._instance = null;
            Awake();
        }


    }
}
