using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointer360 : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform pointerImage;
    float myTime = 0.0f;
    bool active;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            myTime += Time.deltaTime;
            pointerImage.GetComponent<Image>().fillAmount = myTime;
            if (myTime > 1)
            {
                Desactive();
            }
        }

    }

    public void Active()
    {
        ManagePointer(true);
    }
    public void Desactive()
    {
        ManagePointer(false);
    }
    public void ManagePointer(bool state)
    {
        ResetAttribs();
        active = state;

    }
    private void ResetAttribs()
    {
        myTime = 0;
        pointerImage.GetComponent<Image>().fillAmount = myTime;
    }
}
