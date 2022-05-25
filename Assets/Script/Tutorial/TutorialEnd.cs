using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialEnd : MonoBehaviour
{
    public VideoPlayer video_player;

    //動画用オブジェクト
    private GameObject image;

    private PauseActive pause_active;

    private Acceleration acceleration;


    private void Awake()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        image = GameObject.Find("EndTutorial");

        GameObject c = GameObject.Find("Canvas");
        pause_active = c.GetComponent<PauseActive>();

        GameObject p = GameObject.Find("Player");
        acceleration = p.GetComponent<Acceleration>();

        image.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        image.SetActive(false);

        //ポーズ出せる
        pause_active.button_flg = true;

        //加速できる
        acceleration.button_flg = true;
    }
}
