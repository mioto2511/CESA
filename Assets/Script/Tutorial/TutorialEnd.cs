using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialEnd : MonoBehaviour
{
    public VideoPlayer video_player;

    private GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        image = GameObject.Find("EndTutorial");

        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        image.SetActive(false);
    }
}
