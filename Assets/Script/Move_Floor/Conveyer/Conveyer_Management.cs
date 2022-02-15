using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI; // Required when Using UI elements.

public class Conveyer_Management : MonoBehaviour
{
    //ベルトコンベアの稼働状況
    public bool IsOn = false;
    //ベルトコンベアの目標速度
    public float target_driveSpeed = 3.0f;
    //ベルトコンベアの現在の速度
    private float _current_speed = 0;

    public bool right_rotate;
    public bool left_rotate;

    void FixedUpdate()
    {
        _current_speed = IsOn? target_driveSpeed : 0;
        SurfaceEffector2D rb = GetComponent<SurfaceEffector2D>();

        //右回転で右に動く
        if(right_rotate == true)
        {
            rb.speed = _current_speed;
        }
        //左回転で左に動く
        else if (left_rotate == true)
        {
            rb.speed = -_current_speed;
        }

    }
}
