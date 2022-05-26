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

    private bool move_flg = false;

    private GameObject player;

    private MoveCamera move_camera;

    private void Awake()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        GameObject g = GameObject.Find("GoalTrigger");
        goal_flg = g.GetComponent<GoalFlg>();

        GameObject c = GameObject.Find("Main Camera");
        move_camera = c.GetComponent<MoveCamera>();

        player = GameObject.Find("Player");

        parent = this.transform.parent.gameObject;

        //video_player.prepareCompleted += OnPrepareCompleted;
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
            video_player.started += OnMovieStarted;
            video_player.Play();

            move_flg = true;

            //親の透明化
            Color color = parent.GetComponent<SpriteRenderer>().material.color;
            color.a = 0;
            parent.GetComponent<SpriteRenderer>().material.color = color;
        }

        //プレイヤーへ
        if (move_flg)
        {
            count++;

            if(count > 10)
            {
                parent.transform.position = Vector3.MoveTowards(parent.transform.position, player.transform.position, 0.01f);
            }
        }
    }

    //void OnPrepareCompleted(VideoPlayer vp)
    //{

    //}

    void OnMovieStarted(VideoPlayer vp)
    {
        //Debug.Log("a");
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 0.8f);

        move_camera.zoom_flg = true;
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        goal_flg.display_flg = true;
        ef_flg = false;
    }
}
