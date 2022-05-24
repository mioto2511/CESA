using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleScript : MonoBehaviour
{
    private Shutter shutter;

    private bool button_flg = true;

    public VideoPlayer video_player;

    private bool start_flg = true;

    private int count = 0;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        shutter = T.GetComponent<Shutter>();

        
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start_flg)
        {
            count++;

            if(count >= 7)
            {
                start_flg = false;

                video_player.Pause();
            }

            
        }

        if (button_flg)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                button_flg = false;

                shutter.shutter_flg = true;
            }
        }

    }

    public void PlayLoop()
    {
        video_player.Play();
    }
}
