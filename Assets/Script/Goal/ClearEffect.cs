using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ClearEffect : MonoBehaviour
{
    public VideoPlayer video_player;

    private bool start_flg = true;

    private int count = 0;

    public bool ef_flg = false;

    private GoalFlg goal_flg;

    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        GameObject g = GameObject.Find("GoalTrigger");
        goal_flg = g.GetComponent<GoalFlg>();

        parent = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (start_flg)
        //{
        //    count++;

        //    if (count >= 7)
        //    {
        //        start_flg = false;

        //        video_player.Pause();
        //    }
        //}

        if (ef_flg)
        {
            video_player.Play();

            Color color = parent.GetComponent<SpriteRenderer>().material.color;
            color.a = 0;
            parent.GetComponent<SpriteRenderer>().material.color = color;
        }
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        goal_flg.display_flg = true;
        ef_flg = false;
    }
}
