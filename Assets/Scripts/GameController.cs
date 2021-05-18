

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public VideoPlayer video360;
    public Text timeCounter;

    public GameObject[] stages;

    public GameObject question;

    public GameObject warning;

    public int maxTimerSeconds;

    public string currentMinutes;
    public string currentSeconds;

    public Text warningText;



    private bool isWarning = true;
    // public Text totalMinutes;
    // public Text totalSeconds;

    private bool isAnswered = false;
    public int timeWarning;
    public int timeScanning;
    public int timeQuestion;

    public int timeAnswer;

    public int[] stopStages;

    public int[] correctAnswers;

    private int stage = 0;

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
        MyTime = Mathf.Floor(Time.time);
        SetCurrentTimeUI();
        timeCounter.text = currentMinutes + " : " + MyTime.ToString("00");


        if (int.Parse(currentSeconds) == stopStages[stage] && isWarning)
        {
            video360.Pause();
            // stage1.SetActive(true);
            warningText.text = "Escanee el entorno!";
            warning.SetActive(true);

            // question.SetActive(true);
        }
        if (MyTime - stopStages[stage] == timeWarning)
        {
            warning.SetActive(false);
            stages[stage].SetActive(true);
            isWarning = false;

        }

        if (MyTime - (stopStages[stage] + timeWarning) == timeQuestion)
        {
            stages[stage].SetActive(false);
            question.SetActive(true);

        }

        if (MyTime - (stopStages[stage] + timeWarning + timeQuestion) == timeAnswer)
        {
            question.SetActive(false);

            if (!isAnswered)
            {
                warningText.text = "La pregunta no ha sido contestada";
                warning.SetActive(true);
            }

        }

        if (MyTime - (stopStages[stage] + timeWarning + timeQuestion + timeAnswer) == 2)
        {
            stage++;
            warning.SetActive(false);
            video360.Play();

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

    public void AnswerQuestion()
    {

    }

}
