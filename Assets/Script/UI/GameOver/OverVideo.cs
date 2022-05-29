using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class OverVideo : MonoBehaviour
{
    public RawImage image;

    public VideoPlayer video_player;

    private bool buttonflg = false;

    public bool play_flg = false;

    private void Awake()
    {
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
}
