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

        video_player.prepareCompleted += PrepareCompleted;

        video_player.Prepare();

        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 2);
    }

    void PrepareCompleted(VideoPlayer vp)
    {
        vp.prepareCompleted -= PrepareCompleted;
        video_player.started += OnMovieStarted;
        vp.Play();
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //Debug.Log("a");
        //Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        //mat.SetFloat("_Near", chroma);

        //move_camera.zoom_flg = true;
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 0);
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        //goal_flg.display_flg = true;
        //ef_flg = false;
        Fade_Manager.FadeOut(0);
    }
}
