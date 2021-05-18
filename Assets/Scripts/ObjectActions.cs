using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectActions : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject description;

    public Transform pointerImage;

    public AudioSource confirmationSound;

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
        myTime = 0;
        pointerImage.GetComponent<Image>().fillAmount = myTime;

    }

    public void InObject()
    {
        Debug.Log("entro en el azul");
        GetComponent<Renderer>().material.color = Color.blue;
        myTime = 0;
        activo = false;
        encima = true;
        pointerImage.GetComponent<Image>().fillAmount = myTime;


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
        if (encima && myTime <= 1)
        {
            myTime += Time.deltaTime;
            pointerImage.GetComponent<Image>().fillAmount = myTime;

        }
        if (activo && myTime > 1)
        {
            description.SetActive(true);
        }
        if (encima && myTime > 1)
        {
            encima = false;
            confirmationSound.PlayOneShot(confirmationSound.clip);

        }
    }
}
