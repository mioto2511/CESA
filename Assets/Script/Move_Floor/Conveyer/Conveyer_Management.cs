using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI; // Required when Using UI elements.

public class Conveyer_Management : MonoBehaviour
{
    //�x���g�R���x�A�̉ғ���
    public bool IsOn = false;
    //�x���g�R���x�A�̖ڕW���x
    public float target_driveSpeed = 3.0f;
    //�x���g�R���x�A�̌��݂̑��x
    private float _current_speed = 0;

    void FixedUpdate()
    {
        _current_speed = IsOn? target_driveSpeed : 0;
        SurfaceEffector2D rb = GetComponent<SurfaceEffector2D>();
        rb.speed = _current_speed;
    }
}
