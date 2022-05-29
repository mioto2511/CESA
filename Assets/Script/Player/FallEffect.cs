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
        //���悪�I��������̏���
        video_player.loopPointReached += FinishPlayingVideo;

        //���O���[�h
        video_player.Prepare();

        //������
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
            //����Đ�
            video_player.started += OnMovieStarted;
            video_player.Play();

            ef_flg = false;
        }
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //���̉�
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 0.63f);
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        //������
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 2);
    }
}
