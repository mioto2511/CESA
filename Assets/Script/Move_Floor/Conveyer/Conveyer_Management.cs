using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI; // Required when Using UI elements.

public class Conveyer_Management : MonoBehaviour
{
    //ベルトコンベアの稼働状況
    //public bool IsOn = false;
    //ベルトコンベアの目標速度
    public float target_driveSpeed = 3.0f;
    //ベルトコンベアの現在の速度
    private float _current_speed = 0;

    //スクリプト用変数
    GimmickData gimmick_data;

    // Start is called before the first frame update
    void Start()
    {
        //ここで親を取得
        GameObject gimmick = this.transform.parent.gameObject;
        //親オブジェクトのスクリプトから参照したい変数を代入
        gimmick_data = gimmick.GetComponent<GimmickData>();
    }

    void FixedUpdate()
    {
        _current_speed = gimmick_data.IsOn ? target_driveSpeed : 0;
        SurfaceEffector2D rb = GetComponent<SurfaceEffector2D>();

        //右回転で右に動く
        if(gimmick_data.right_rotate == true)
        {
            rb.speed = _current_speed;
        }
        //左回転で左に動く
        else if (gimmick_data.left_rotate == true)
        {
            rb.speed = -_current_speed;
        }
    }
}
