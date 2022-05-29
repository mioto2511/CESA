using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WallEffect : MonoBehaviour
{
    public VideoPlayer video_player;

    private void Awake()
    {

        video_player.prepareCompleted += PrepareCompleted;

        video_player.Prepare();

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
        mat.SetFloat("_Near", 0.78f);
    }
}
