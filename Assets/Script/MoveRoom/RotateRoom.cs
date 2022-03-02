using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    [SerializeField, Tooltip("ターゲットオブジェクト")]
    private GameObject target_object;

    [SerializeField, Tooltip("回転軸")]
    private Vector3 RotateAxis = Vector3.forward;

    [SerializeField, Tooltip("速度係数")]
    private float SpeedFactor = 0.1f;

    //回すか
    public bool rotate_flg = false;

    //何周りか
    private bool right_rotate = false;
    private bool left_rotate = false;

    //部屋同士が当たったか
    public bool room_hit = false;

    //自身のtf
    Transform my_transform;
    Vector3 my_rotate;

    void Update()
    {
        // transformを取得
        my_transform = this.transform;

        //回転方向の変更
        if (Input.GetKeyDown("joystick button 5"))//右
        {
            right_rotate = true;
            left_rotate = false;
            Debug.Log("R");
        }
        else if (Input.GetKeyDown("joystick button 4"))//左
        {
            left_rotate = true;
            right_rotate = false;
            Debug.Log("L");
        }

        //部屋が当たった
        if (room_hit == true)
        {
            room_hit = false;
        }

        // 指定オブジェクトを中心に回転する
        if (rotate_flg == true)
        {
            if(right_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / -SpeedFactor) * Time.deltaTime
                );
            }
            else if (left_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / SpeedFactor) * Time.deltaTime
                );
            }
        }       
    }
}
