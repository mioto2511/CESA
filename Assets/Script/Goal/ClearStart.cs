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
        //動画が終わった時の処理
        video_player.loopPointReached += FinishPlayingVideo;

        clear_loop = loop.GetComponent<ClearLoop>();

        //事前ロード
        video_player.Prepare();

        //透明化
        image.enabled = false;
    }

    //private void Start()
    //{
    //    //動画が終わった時の処理
    //    video_player.loopPointReached += FinishPlayingVideo;

    //    clear_loop = loop.GetComponent<ClearLoop>();

    //    //事前ロード
    //    video_player.Prepare();

    //    //透明化
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
        //実体化
        image.enabled = true;
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        clear_loop.loop_flg = true;
    }
}
