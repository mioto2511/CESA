using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ClearLoop : MonoBehaviour
{
    public VideoPlayer video_player;

    public RawImage image;

    public bool loop_flg = false;

    public bool button_flg = false;

    public GameObject s_image;

    private GoalFlg goal_flg;


    private void Awake()
    {
        GameObject p = GameObject.Find("GoalTrigger");
        goal_flg = p.GetComponent<GoalFlg>();

        //事前ロード
        video_player.Prepare();

        //透明化
        image.enabled = false;
    }

    //private void Start()
    //{
    //    //事前ロード
    //    video_player.Prepare();

    //    //透明化
    //    image.enabled = false;
    //}

    // Update is called once per frame
    void Update()
    {
        if (loop_flg)
        {
            //動画再生
            video_player.started += OnMovieStarted;
            video_player.Play();

            loop_flg = false;
        }
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //実体化
        image.enabled = true;
        s_image.SetActive(false);
        goal_flg.button_flg = true;
    }
}
