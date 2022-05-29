using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class UpFrame : MonoBehaviour
{
    public VideoPlayer video_player;

    public RawImage image;

    private GameObject l_image;

    public bool end_flg = false;

   

    private void Awake()
    {
        //video_player.loopPointReached += FinishPlayingVideo;

        l_image = GameObject.Find("Canvas/Frame");

        

        //���O���[�h
        video_player.Prepare();

        //������
        image.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (end_flg)
        {
            //����Đ�
            video_player.started += OnMovieStarted;
            video_player.Play();
        }
    }

    //public void FinishPlayingVideo(VideoPlayer vp)
    //{
    //    this.gameObject.SetActive(false);
    //}

    void OnMovieStarted(VideoPlayer vp)
    {
        //���̉�
        image.enabled = true;
        l_image.SetActive(false);
    }
}
