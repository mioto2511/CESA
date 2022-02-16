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

    //public bool right_rotate;
    //public bool left_rotate;

    MainPowrGear main_powr_gear;

    // Start is called before the first frame update
    void Start()
    {
        //ここで親を取得
        GameObject maingear = this.transform.parent.gameObject;
        //親オブジェクトのスクリプトから参照したい変数を代入
        main_powr_gear = maingear.GetComponent<MainPowrGear>();
    }

    void FixedUpdate()
    {


        _current_speed = main_powr_gear.IsOn ? target_driveSpeed : 0;
        SurfaceEffector2D rb = GetComponent<SurfaceEffector2D>();

        //右回転で右に動く
        if(main_powr_gear.right_rotate == true)
        {
            rb.speed = _current_speed;
        }
        //左回転で左に動く
        else if (main_powr_gear.left_rotate == true)
        {
            rb.speed = -_current_speed;
        }

    }
}
