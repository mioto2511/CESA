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

        //���O���[�h
        video_player.Prepare();

        //������
        image.enabled = false;
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

    void OnMovieStarted(VideoPlayer vp)
    {
        //���̉�
        image.enabled = true;
        l_image.SetActive(false);

        //�|�[�Y�o����
        pause_active.button_flg = true;

        //�����ł���
        acceleration.button_flg = true;

        //��]�ł���
        rotate_start.botton_flg = true;
    }
    public void FinishPlayingVideo(VideoPlayer vp)
    {
        

        this.gameObject.SetActive(false); 
    }
}
