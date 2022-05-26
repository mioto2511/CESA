using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class TutoiralStart : MonoBehaviour
{
    public VideoPlayer video_player;

    public GameObject l_image;

    public static TutoiralStart instance;

    private Tutorial tutorial;

    public bool play_flg = false;

    public RawImage image;


    private void Awake()
    {
        //動画が終わった時の処理
        video_player.loopPointReached += FinishPlayingVideo;

        l_image = GameObject.Find("Tutorial");
        tutorial = l_image.GetComponent<Tutorial>();

        

        //事前ロード
        video_player.Prepare();

        //透明化
        image.enabled = false;
    }

    private void Update()
    {
        if (play_flg)
        {
            play_flg = false;

            video_player.started += OnMovieStarted;
            video_player.Play();
            
            ChainSE();
        }
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //実体化
        image.enabled = true;
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        tutorial.loop_flg = true;
        //this.gameObject.SetActive(false);
    }

    public void ChainSE()
    {
        SEManager.Instance.Play(SEPath.SE_008);
    }
}
