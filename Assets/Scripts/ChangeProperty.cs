using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProperty : MonoBehaviour
{
    [SerializeField] GameController gameController;

    public GameObject description;
    public AudioSource confirmationSound;

    bool encima = false;
    public bool startSound;
    float MyTime = 0.0f;
    bool active = false;

    public void Action()
    {
        GetComponent<Renderer>().material.color = Color.black;
        gameController.StopVideo();

    }

    public void ShowInformation()
    {
        Debug.Log("Im showing the information");
    }

    private void Update()
    {
        MyTime += Time.deltaTime;
        if (active && MyTime > 1)
        {
            description.SetActive(true);
        }
        if (encima && MyTime > 1)
        {
            confirmationSound.PlayOneShot(confirmationSound.clip);
            encima = false;
        }
    }
}
