using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class Tutorial : MonoBehaviour
{
    private GameObject e_image;

    public VideoPlayer video_player;

    private RotateStart rotate_start;

    public static Tutorial instance;

    public bool loop_flg = false;

    private TutorialEnd tutorial_end;

    public RawImage image;

    private GameObject s_image;

    private void Awake()
    {
        GameObject obj3 = GameObject.Find("Room");
        rotate_start = obj3.GetComponent<RotateStart>();
        rotate_start.botton_flg = false;

        e_image = GameObject.Find("EndTutorial");
        tutorial_end = e_image.GetComponent<TutorialEnd>();

        s_image = GameObject.Find("StartTutorial");


        //事前ロード
        video_player.Prepare();

        image.enabled = false;

        //透明化
        //Material mat = this.gameObject.GetComponent<>().material;
        //mat.SetFloat("_Near", 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loop_flg)
        {
            //動画再生
            video_player.started += OnMovieStarted;
            video_player.Play();

            loop_flg = false;
        }

        if (Input.GetKeyDown("joystick button 0"))
        {           
            tutorial_end.end_flg = true;

            //this.gameObject.SetActive(false);

            ChainSE();
        }
    }
    void OnMovieStarted(VideoPlayer vp)
    {
        //実体化
        image.enabled = true;
        s_image.SetActive(false);
    }

    private void ChainSE()
    {
        SEManager.Instance.Play(SEPath.SE_008);
    }

}
