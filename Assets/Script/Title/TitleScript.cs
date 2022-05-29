using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using KanKikuchi.AudioManager;

public class TitleScript : MonoBehaviour
{
    private Shutter shutter;

    private bool button_flg = false;

    public VideoPlayer video_player;

    private bool start_flg = true;

    private int count = 0;

    public bool loop_flg = false;

    public GameObject image;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        shutter = T.GetComponent<Shutter>();

        video_player.Prepare();

        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //if (start_flg)
        //{
        //    count++;

        //    if(count >= 8)
        //    {
        //        start_flg = false;

        //        video_player.Pause();
        //    }


        //}

        if (loop_flg)
        {
            video_player.started += OnMovieStarted;
            video_player.Play();
        }

        if (button_flg)
        {
            if (Input.anyKeyDown)//("joystick button 0"))
            {
                button_flg = false;
               
                shutter.shutter_flg = true;

                // BGM止める
                BGMManager.Instance.Stop(BGMPath.BGM_002);
                // タイトル遷移SE
                Debug.Log("titlese");
                SEManager.Instance.Play(SEPath.SE_009,volumeRate:0.5f);
            }
        }

    }

    void OnMovieStarted(VideoPlayer vp)
    {
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 0);
        //button_flg = true;
        image.SetActive(false);

        //遅らせて処理するもの
        Invoke("DelayMethod", 0.25f);
    }

    private void DelayMethod()
    {
        button_flg = true;
    }

    //public void PlayLoop()
    //{
    //    video_player.Play();

    //}
}
