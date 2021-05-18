

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    private bool isAnswered = false;
    public int timeWarning;
    public int timeScanning;
    public int timeQuestion;

    public int timeAnswer;

    private int offsetTime = 0;

    public int[] stopStages;

    public int[] correctAnswers;

    private int stage = 0;

    int MyTime = 0;

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
        currentSeconds = ((int)video360.time).ToString("00");


        // timeCounter.text = currentMinutes + " : " + currentSeconds;

        // Debug.Log(timeCounter.text);
    }

    // Update is called once per frame
    void Update()
    {
        MyTime = (int)Mathf.Floor(Time.time);
        SetCurrentTimeUI();
        Debug.Log(MyTime - (stopStages[stage] + offsetTime));
        Debug.Log(timeWarning);


        if (int.Parse(currentSeconds) == stopStages[stage] && isWarning)
        {
            video360.Pause();
            warningText.text = "Escanee el entorno!";
            warning.SetActive(true);

        }

        if ((MyTime - (stopStages[stage] + offsetTime)) == timeWarning)
        {
            warning.SetActive(false);
            stages[stage].SetActive(true);
            isWarning = false;
            timeCounter.text = currentMinutes + " : " + timeWarning.ToString();

        }

        if ((MyTime - (stopStages[stage] + offsetTime)) > timeWarning && (MyTime - (stopStages[stage] + timeWarning + offsetTime) < timeQuestion))
        {
            Timer.SetActive(true);
            timeCounter.text = currentMinutes + " : " + (timeQuestion + (stopStages[stage] + timeWarning + offsetTime) - MyTime).ToString("00");

        }
        else if (((MyTime - (stopStages[stage] + timeWarning + timeQuestion + offsetTime) < timeAnswer)))
        {
            timeCounter.text = currentMinutes + " : " + (timeAnswer + (stopStages[stage] + timeWarning + timeQuestion + offsetTime) - MyTime).ToString("00");

        }


        if (MyTime - (stopStages[stage] + timeWarning + offsetTime) == timeQuestion)
        {
            stages[stage].SetActive(false);
            question.SetActive(true);
            timeCounter.text = currentMinutes + " : " + timeQuestion.ToString();

        }

        if (((MyTime - (stopStages[stage] + timeWarning + timeQuestion + offsetTime) == timeAnswer) && !wasAnswered) || isAnswered)
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

        if (MyTime - (stopStages[stage] + timeWarning + timeQuestion + timeAnswer + offsetTime) == 2)
        {
            Timer.SetActive(false);
            stage++;
            warning.SetActive(false);
            wasAnswered = false;
            isAnswered = false;
            video360.Play();
            isWarning = true;
            offsetTime = MyTime - int.Parse(currentSeconds);
        }
        if (stages.Length == stage)
        {
            SceneManager.LoadScene("Puntuacion");
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
