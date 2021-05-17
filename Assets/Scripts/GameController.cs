

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public VideoPlayer video360;
    public Text timeCounter;

    public GameObject stage1;

    public string currentMinutes;
    public string currentSeconds;
    // public Text totalMinutes;
    // public Text totalSeconds;

    float MyTime = 0.0f;

    // Start is called before the first frame update

    private void Start()
    {
        // currentMinutes = new Text();
        // currentSeconds = new Text();

    }
    void SetCurrentTimeUI()
    {

        currentMinutes = Mathf.Floor((int)video360.time / 60).ToString("00");
        currentSeconds = ((int)video360.time % 60).ToString("00");
        // Debug.Log("Hola don pepito");


        timeCounter.text = currentMinutes + " : " + currentSeconds;

        // Debug.Log(timeCounter.text);
        // Debug.Log("Hola don jose");
    }
    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {
        MyTime += Time.deltaTime;
        SetCurrentTimeUI();

        if (int.Parse(currentSeconds) == 24)
        {
            video360.Pause();
            stage1.SetActive(true);
        }

    }

    public void PlayVideo()
    {
        video360.Play();
    }

    public void StopVideo()
    {
        video360.Pause();
    }
}
