using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleStart : MonoBehaviour
{
    public VideoPlayer video_player;

    public GameObject title;

    public TitleScript title_script;

    private void Awake()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        video_player.prepareCompleted += PrepareCompleted;

        video_player.Prepare();

        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 2);

        //GameObject t = GameObject.Find("TitleStart");
        //title_script = t.GetComponent<TitleScript>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)//("joystick button 0"))
        {
            title_script.loop_flg = true;
        }
    }

    void PrepareCompleted(VideoPlayer vp)
    {
        vp.prepareCompleted -= PrepareCompleted;
        video_player.started += OnMovieStarted;
        vp.Play();
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 0);
        
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        //title.SetActive(true);
        //this.gameObject.SetActive(false);
        //Invoke("DelayMethod", 0.065f);
        //this.gameObject.SetActive(false);

        //title_script.PlayLoop();

        //this.gameObject.SetActive(false);
        title_script.loop_flg = true;
    }

    //íxâÑèàóù
    private void DelayMethod()
    {
        this.gameObject.SetActive(false);
    }

}
