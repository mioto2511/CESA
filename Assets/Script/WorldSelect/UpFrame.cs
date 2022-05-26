using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UpFrame : MonoBehaviour
{
    public VideoPlayer video_player;

    private void Awake()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        this.gameObject.SetActive(false);
    }
}
