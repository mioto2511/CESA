using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndingScript : MonoBehaviour
{
    public VideoPlayer video_player;


    private void Awake()
    {
        video_player.loopPointReached += FinishPlayingVideo;

        video_player.Prepare();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (ef_flg)
        //{
        //    video_player.started += OnMovieStarted;
        //    video_player.Play();

        //    move_flg = true;

        //    //êeÇÃìßñæâª
        //    Color color = parent.GetComponent<SpriteRenderer>().material.color;
        //    color.a = 0;
        //    parent.GetComponent<SpriteRenderer>().material.color = color;
        //}
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //Debug.Log("a");
        //Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        //mat.SetFloat("_Near", chroma);

        //move_camera.zoom_flg = true;
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        //goal_flg.display_flg = true;
        //ef_flg = false;
    }
}
