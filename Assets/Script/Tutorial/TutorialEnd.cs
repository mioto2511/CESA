using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TutorialEnd : MonoBehaviour
{
    public VideoPlayer video_player;

    private PauseActive pause_active;

    private Acceleration acceleration;

    private RotateStart rotate_start;

    public bool end_flg = false;

    public RawImage image;

    private GameObject l_image;
    private void Awake()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        GameObject c = GameObject.Find("Canvas");
        pause_active = c.GetComponent<PauseActive>();

        GameObject p = GameObject.Find("Player");
        acceleration = p.GetComponent<Acceleration>();

        GameObject obj3 = GameObject.Find("Room");
        rotate_start = obj3.GetComponent<RotateStart>();

        l_image = GameObject.Find("Tutorial");

        //事前ロード
        video_player.Prepare();

        //透明化
        image.enabled = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (end_flg)
        {
            //動画再生
            video_player.started += OnMovieStarted;
            video_player.Play();
        }
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //実体化
        image.enabled = true;
        l_image.SetActive(false);

        //ポーズ出せる
        pause_active.button_flg = true;

        //加速できる
        acceleration.button_flg = true;

        //回転できる
        rotate_start.botton_flg = true;
    }
    public void FinishPlayingVideo(VideoPlayer vp)
    {
        

        this.gameObject.SetActive(false); 
    }
}
