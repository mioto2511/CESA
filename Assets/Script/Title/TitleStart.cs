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

        //GameObject t = GameObject.Find("TitleStart");
        //title_script = t.GetComponent<TitleScript>();
    }
 

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        //title.SetActive(true);
        //this.gameObject.SetActive(false);
        //Invoke("DelayMethod", 0.065f);
        //this.gameObject.SetActive(false);

        title_script.PlayLoop();

        this.gameObject.SetActive(false);
    }

    //íxâÑèàóù
    private void DelayMethod()
    {
        this.gameObject.SetActive(false);
    }

}
