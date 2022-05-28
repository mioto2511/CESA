using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class DownFrame : MonoBehaviour
{
    public VideoPlayer video_player;

    private GameObject l_image;

    public static TutoiralStart instance;

    private LoopFrame loop_frame;

    public bool play_flg = false;

    public RawImage image;

    private void Awake()
    {
        //動画が終わった時の処理
        video_player.loopPointReached += FinishPlayingVideo;

        l_image = GameObject.Find("Canvas/Frame");
        loop_frame = l_image.GetComponent<LoopFrame>();



        //事前ロード
        video_player.Prepare();

        //透明化
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (play_flg)
        {
            play_flg = false;

            video_player.started += OnMovieStarted;
            video_player.Play();
        }
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //実体化
        image.enabled = true;
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        loop_frame.play_flg = true;
    }
}
