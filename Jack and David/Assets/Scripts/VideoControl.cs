using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject ButtonPanel;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        ButtonPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp){
        ButtonPanel.SetActive(true);
        Debug.Log("Video Over");
    }

    public void LoadScene(string sceneName){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
