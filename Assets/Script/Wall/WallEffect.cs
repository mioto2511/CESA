using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WallEffect : MonoBehaviour
{
    public VideoPlayer video_player;

    private int count= 0;
    bool flg = true;

    public float chroma;

    private void Awake()
    {
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 2);

        //video_player.prepareCompleted += PrepareCompleted;

        video_player.Prepare();

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (flg)
        {
            count++;
            if(count >= 50)
            {
                video_player.started += OnMovieStarted;
                video_player.Play();
                flg = false;
            }
            
        }
    }
    void PrepareCompleted(VideoPlayer vp)
    {
        //vp.prepareCompleted -= PrepareCompleted;
        video_player.started += OnMovieStarted;
        vp.Play();
    }
    void OnMovieStarted(VideoPlayer vp)
    {
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", chroma);
    }
}
