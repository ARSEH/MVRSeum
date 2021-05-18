using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Putuacion : MonoBehaviour
{
    // Start is called before the first frame update

    public Text finalScoreText;
    void Start()
    {
        finalScoreText.text = "Puntuación: " + PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
