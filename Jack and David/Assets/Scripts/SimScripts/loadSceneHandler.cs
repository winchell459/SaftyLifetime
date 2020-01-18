using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadSceneHandler : MonoBehaviour
{
    private bool triggered = false;
    public string SceneName = "MainMenu";

    // Update is called once per frame
    void Update()
    {
        if(triggered){
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
        }
    }

    public void TriggerEvent()
    {
        triggered = true;
    }
}
