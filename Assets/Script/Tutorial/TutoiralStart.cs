using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutoiralStart : MonoBehaviour
{
    public VideoPlayer video_player;

    private GameObject s_image;
    public GameObject image;

    public bool play_flg = false;

    private void Awake()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        s_image = GameObject.Find("StartTutorial");

        video_player.Pause();
    }

    private void Update()
    {
        if (play_flg)
        {
            play_flg = false;

            video_player.Play();
        }
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        image.SetActive(true);
        s_image.SetActive(false);
    }
}
