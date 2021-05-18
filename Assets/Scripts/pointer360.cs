using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointer360 : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform pointerImage;

    public AudioSource confirmationSound;
    public bool startSound;

    public bool clickable = false;

    float myTime = 0.0f;
    bool active;

    bool onIt;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onIt && myTime <= 1)
        {
            myTime += Time.deltaTime;
            pointerImage.GetComponent<Image>().fillAmount = myTime;

        }
        if (onIt && myTime > 1)
        {
            confirmationSound.PlayOneShot(confirmationSound.clip);
            onIt = false;
            clickable = true;
        }

    }

    public void Active()
    {
        ManagePointer(true);
    }
    public void Desactive()
    {
        ManagePointer(false);
        active = false;
    }

    public void Action()
    {
        if (clickable)
        {

        }
    }
    public void ManagePointer(bool state)
    {
        ResetAttribs();
        onIt = state;
        clickable = false;

    }
    private void ResetAttribs()
    {
        myTime = 0;
        pointerImage.GetComponent<Image>().fillAmount = myTime;
    }
}
