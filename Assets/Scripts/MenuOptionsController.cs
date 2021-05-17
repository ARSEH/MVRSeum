using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptionsController : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    public void ChangeScene(string scene = null)
    {
        Debug.Log(scene);
        if (scene.Length != 0)
        {
            SceneManager.LoadScene(scene);
            Debug.Log("loaded scene");

        }
        else
        {
            Debug.Log("Exit application");
            Application.Quit();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
