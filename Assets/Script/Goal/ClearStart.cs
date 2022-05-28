using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ClearStart : MonoBehaviour
{
    public VideoPlayer video_player;

    public RawImage image;

    private ClearLoop clear_loop;

    public GameObject loop;

    public bool play_flg = false;

    private void Awake()
    {
        //���悪�I��������̏���
        video_player.loopPointReached += FinishPlayingVideo;

        clear_loop = loop.GetComponent<ClearLoop>();

        //���O���[�h
        video_player.Prepare();

        //������
        image.enabled = false;
    }

    //private void Start()
    //{
    //    //���悪�I��������̏���
    //    video_player.loopPointReached += FinishPlayingVideo;

    //    clear_loop = loop.GetComponent<ClearLoop>();

    //    //���O���[�h
    //    video_player.Prepare();

    //    //������
    //    image.enabled = false;
    //}

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
        clear_loop.loop_flg = true;
    }
}
