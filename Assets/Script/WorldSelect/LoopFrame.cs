using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class LoopFrame : MonoBehaviour
{
    public bool loop_flg = true;

    public bool play_flg = false;

    public VideoPlayer video_player;

    public GameObject e_image;

    private UpFrame up_frame;

    public RawImage image;

    private GameObject s_image;

    private CuesorManager cuesor_manager;

    private void Awake()
    {
        s_image = GameObject.Find("Canvas/Start");

        e_image = GameObject.Find("Canvas/End");
        up_frame = e_image.GetComponent<UpFrame>();

        GameObject c = GameObject.Find("Cursor");
        cuesor_manager = c.GetComponent<CuesorManager>();


        //éñëOÉçÅ[Éh
        video_player.Prepare();

        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (play_flg)
        {
            //ìÆâÊçƒê∂
            video_player.started += OnMovieStarted;
            video_player.Play();

            play_flg = false;
        }
        if (!loop_flg)
        {
            up_frame.end_flg = true;
        }
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //é¿ëÃâª
        image.enabled = true;
        s_image.SetActive(false);
        cuesor_manager.button_flg = true;
    }
}
