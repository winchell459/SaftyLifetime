using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winchellQuiz : MonoBehaviour
{
    public int correct;
    public string NextScene;
    public GameObject[] questionPanels;
    private int questionNumber = 0;


    public void CorrectChoice(){
        correct += 1;
        if (correct >= 5){
            UnityEngine.SceneManagement.SceneManager.LoadScene(NextScene);
        }

        questionPanels[questionNumber].SetActive(false);
        questionNumber += 1;
        questionPanels[questionNumber].SetActive(true);
    }
    public void WrongChoice(){
        
    }
}
