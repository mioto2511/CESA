using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutoiralStart : MonoBehaviour
{
    public VideoPlayer video_player;

    private GameObject s_image;
    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        s_image = GameObject.Find("StartTutorial");
        //image = GameObject.Find("Tutorial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        image.SetActive(true);
        s_image.SetActive(false);
    }
}
