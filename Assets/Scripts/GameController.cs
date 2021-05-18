

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public VideoPlayer video360;
    public Text timeCounter;
    public GameObject Timer;

    public GameObject[] stages;

    public GameObject question;

    public GameObject warning;

    public Text scoreText;

    public int maxTimerSeconds;

    public string currentMinutes;
    public string currentSeconds;

    public Text warningText;

    private int score = 0;

    private int questionAnswered;

    private bool wasAnswered;



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
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        wasAnswered = false;
        isAnswered = false;

    }
    void SetCurrentTimeUI()
    {

        currentMinutes = Mathf.Floor((int)video360.time / 60).ToString("00");
        currentSeconds = ((int)video360.time % 60).ToString("00");


        // timeCounter.text = currentMinutes + " : " + currentSeconds;

        // Debug.Log(timeCounter.text);
    }

    // Update is called once per frame
    void Update()
    {
        MyTime = Mathf.Floor(Time.time);
        SetCurrentTimeUI();


        if (int.Parse(currentSeconds) == stopStages[stage] && isWarning)
        {
            video360.Pause();
            warningText.text = "Escanee el entorno!";
            warning.SetActive(true);

        }

        if (MyTime - stopStages[stage] == timeWarning)
        {
            warning.SetActive(false);
            stages[stage].SetActive(true);
            isWarning = false;
            timeCounter.text = currentMinutes + " : " + timeWarning.ToString();

        }

        if (MyTime - stopStages[stage] > timeWarning && (MyTime - (stopStages[stage] + timeWarning) < timeQuestion))
        {
            Timer.SetActive(true);
            timeCounter.text = currentMinutes + " : " + (timeQuestion + (stopStages[stage] + timeWarning) - MyTime).ToString("00");

        }
        else if (((MyTime - (stopStages[stage] + timeWarning + timeQuestion) < timeAnswer)))
        {
            timeCounter.text = currentMinutes + " : " + (timeAnswer + (stopStages[stage] + timeWarning + timeQuestion) - MyTime).ToString("00");

        }


        if (MyTime - (stopStages[stage] + timeWarning) == timeQuestion)
        {
            stages[stage].SetActive(false);
            question.SetActive(true);
            timeCounter.text = currentMinutes + " : " + timeQuestion.ToString();

        }

        if (((MyTime - (stopStages[stage] + timeWarning + timeQuestion) == timeAnswer) && !wasAnswered) || isAnswered)
        {
            question.SetActive(false);

            if (!isAnswered && !wasAnswered)
            {
                warningText.text = "La pregunta no ha sido contestada";
                warning.SetActive(true);

            }
            else if (isAnswered)
            {
                if (questionAnswered == correctAnswers[stage])
                {
                    warningText.text = "Respuesta correcta!";
                    score += 1;
                    warning.SetActive(true);

                }
                else if (questionAnswered != correctAnswers[stage])
                {
                    warningText.text = "Respuesta incorrecta!";
                    score -= 1;
                    warning.SetActive(true);

                }


                isAnswered = false;
                wasAnswered = true;
                scoreText.text = "Score: " + score.ToString();
            }
        }

        if (MyTime - (stopStages[stage] + timeWarning + timeQuestion + timeAnswer) == 2)
        {
            Timer.SetActive(false);
            stage++;
            warning.SetActive(false);
            wasAnswered = false;
            video360.Play();

        }

        // Debug.Log(score);

    }

    public void PlayVideo()
    {
        video360.Play();
    }

    public void StopVideo()
    {
        video360.Pause();
    }

    public void AnswerQuestion(int indexAnswer)
    {
        Debug.Log("Entre aquí");
        questionAnswered = indexAnswer;
        isAnswered = true;

    }

}
