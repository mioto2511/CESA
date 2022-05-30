using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialActive : MonoBehaviour
{
    private TutoiralStart tutoiral_start;

    private PauseActive pause_active;

    private RotateStart rotate_start;

    private Acceleration acceleration;

    private int count = 0;

    private int display_count = 150;

    private void Awake()
    {
        GameObject s = GameObject.Find("StartTutorial");
        tutoiral_start = s.GetComponent<TutoiralStart>();

        //ポーズを出せなくする
        pause_active = this.GetComponent<PauseActive>();
        pause_active.button_flg = false;

        //加速できなくする
        GameObject p = GameObject.Find("Player");
        acceleration = p.GetComponent<Acceleration>();
        acceleration.button_flg = false;

        GameObject obj3 = GameObject.Find("Room");
        rotate_start = obj3.GetComponent<RotateStart>();
        rotate_start.botton_flg = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        count++;

        if (count >= display_count)
        {
            tutoiral_start.play_flg = true;

            Destroy(this);
        }
    }
}
