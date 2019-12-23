using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp){
        Debug.Log("Video Over");
    }
}
