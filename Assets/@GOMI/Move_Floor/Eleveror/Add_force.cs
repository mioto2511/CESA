using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_force : MonoBehaviour
{
    //ベルトコンベアの稼働状況
    public bool IsOn = false;
    //ベルトコンベアの目標速度
    public float target_driveSpeed = 3.0f;
    //ベルトコンベアの現在の速度
    private float _current_speed = 0;

    void FixedUpdate()
    {
        _current_speed = IsOn ? target_driveSpeed : 0;
        SurfaceEffector2D rb = GetComponent<SurfaceEffector2D>();
        rb.speed = _current_speed;
    }
}
