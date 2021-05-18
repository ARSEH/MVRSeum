using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;

    [SerializeField] GameController gameController;

    [SerializeField] string scene;

    // Update is called once per frame
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetKeyDown("return"))
            {
                animator.SetBool("pressed", true);
                Debug.Log("pressed");
                Invoke("ActionButton", 0.7f);
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }

    void ActionButton()
    {
        gameController.AnswerQuestion(thisIndex);

    }
}
