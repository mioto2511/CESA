using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FallEffect : MonoBehaviour
{
    public VideoPlayer video_player;

    public bool ef_flg = false;

    private void Awake()
    {
        //動画が終わった時の処理
        video_player.loopPointReached += FinishPlayingVideo;

        //事前ロード
        video_player.Prepare();

        //透明化
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ef_flg)
        {
            //動画再生
            video_player.started += OnMovieStarted;
            video_player.Play();

            ef_flg = false;
        }
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //実体化
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 0.63f);
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        //透明化
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 2);
    }
}
