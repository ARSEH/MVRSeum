using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProperty : MonoBehaviour
{
    float MyTime = 0.0f;
    bool active = false;
    public void Desactive()
    {
        GetComponent<Renderer>().material.color = Color.red;
        active = false;
    }

    public void Active()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        MyTime = 0;
        active = true;

    }

    public void Action()
    {
        GetComponent<Renderer>().material.color = Color.black;
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
            ShowInformation();
        }
    }
}
