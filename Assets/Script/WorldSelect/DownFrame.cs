using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DownFrame : MonoBehaviour
{
    public VideoPlayer video_player;

    public GameObject image;

    private void Awake()
    {
        video_player.loopPointReached += FinishPlayingVideo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        image.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
