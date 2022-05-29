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
        //���悪�I��������̏���
        video_player.loopPointReached += FinishPlayingVideo;

        l_image = GameObject.Find("Canvas/Frame");
        loop_frame = l_image.GetComponent<LoopFrame>();



        //���O���[�h
        video_player.Prepare();

        //������
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
        //���̉�
        image.enabled = true;
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        loop_frame.play_flg = true;
    }
}
