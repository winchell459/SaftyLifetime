using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizScript : MonoBehaviour
{
    public int correct;
    public string NextScene;
    public GameObject[] questionPanels;
    private int questionNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void correctChoice()
    {
        correct += 1;
        if (correct >= 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(NextScene);
        }
        questionPanels[questionNumber].SetActive(false);
        questionNumber += 1;
        questionPanels[questionNumber].SetActive(true);
    }
}
