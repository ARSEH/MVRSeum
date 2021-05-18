using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActions : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject description;

    bool encima = false;
    public bool startSound;
    float myTime = 0.0f;
    bool activo = false;

    public void OutObject()
    {
        Debug.Log("Entro en el rojo");
        GetComponent<Renderer>().material.color = Color.red;
        activo = false;
        description.SetActive(false);
        encima = false;

    }

    public void InObject()
    {
        Debug.Log("entro en el azul");
        GetComponent<Renderer>().material.color = Color.blue;
        myTime = 0;
        activo = false;
        encima = true;

        // description.SetActive(true);

    }

    public void ClickObject()
    {
        Debug.Log("entro en el verde");
        GetComponent<Renderer>().material.color = Color.green;
        activo = true;
        encima = false;
    }

    public void ShowInformation()
    {
        Debug.Log("Im showing the information");
    }

    private void Update()
    {
        myTime += Time.deltaTime;
        if (activo && myTime > 1)
        {
            description.SetActive(true);
        }
        if (encima && myTime > 1)
        {
            encima = false;
        }
    }
}
