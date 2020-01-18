using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppHandler : MonoBehaviour
{
    public void LoadLevel(){
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }
}
