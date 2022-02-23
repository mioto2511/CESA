using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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

        //ボタンを押すと回転
        //if (Input.GetKeyDown("joystick button 0"))//右下
        //{
        //    rotate_flg = true;
        //}

        // 指定オブジェクトを中心に回転する
        if (rotate_flg == true)//右下
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
