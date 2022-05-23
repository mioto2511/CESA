using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleStart : MonoBehaviour
{
    public VideoPlayer video_player;

    public GameObject title;

    private void Awake()
    {
        video_player.loopPointReached += FinishPlayingVideo;

    }
 

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        title.SetActive(true);
        //this.gameObject.SetActive(false);
        Invoke("DelayMethod", 0.1f);
    }

    //íxâÑèàóù
    private void DelayMethod()
    {
        this.gameObject.SetActive(false);
    }

}
