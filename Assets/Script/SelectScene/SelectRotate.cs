using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRotate : MonoBehaviour
{
    private bool rotate_flg = true;

    private float deadzone = 0.2f;

    private bool up_flg = false;
    private bool down_flg = false;

    private float max_rotate = 45f;
    private float now_rotate = 0;
    private float speed = 0.1f;

    //ステックの開始地点
    private float start_radian = 0;

    //ステックの前回角度
    private float old_radian = 0;

    //初期位置フラグ
    private bool initial_flg = true;

    // Update is called once per frame
    void Update()
    {
        if (rotate_flg)
        {          
            float lsh = Input.GetAxis("L_Stick_H");//横軸
            float lsv = Input.GetAxis("L_Stick_V");//縦軸

            //if(lsv > deadzone)
            //{
            //    up_flg = true;
            //    rotate_flg = false;
            //}
            //else if(lsv < -deadzone)
            //{
            //    down_flg = true;
            //    rotate_flg = false;
            //}

            //ステックの角度産出
            float radian = Mathf.Atan2(lsv, lsh) * Mathf.Rad2Deg;
            if (radian < 0)
            {
                radian += 360;
            }
            //スティック入力がはいったら
            if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
            {
                //初期位置の時
                if (initial_flg)
                {
                    initial_flg = false;

                    //スティックの開始角度
                    start_radian = radian;

                }


                if (up_flg == false && down_flg == false)
                {
                    float now_radian = start_radian - radian;

                    //0～360で飛ぶのを改善
                    if (old_radian >= 0 && now_radian < -200)
                    {
                        now_radian += 360;
                    }
                    else if (old_radian <= 0 && now_radian > 200)
                    {
                        now_radian -= 360;
                    }

                    //90度回転したら回転開始
                    if (now_radian >= 90)
                    { 
                        up_flg = true;

                        rotate_flg = false;

                        initial_flg = true;
                    }
                    else if (now_radian <= -90)
                    {
                        down_flg = true;

                        rotate_flg = false;

                        initial_flg = true;
                    }

                    //保存
                    old_radian = now_radian;
                }
            }
            else if (lsh == 0 && lsv == 0)
            {
                //回転初期位置の初期化
                start_radian = 0;
                old_radian = 0;
                initial_flg = true;
            }
        }
    }

    void FixedUpdate()
    {

        if (up_flg)
        {
            this.transform.Rotate(new Vector3(0, 0, -speed));

            now_rotate += -speed;

            if(-max_rotate >= now_rotate)
            {
                up_flg = false;
                now_rotate = 0;
                Invoke("DelayMethod", 0.25f);
            }
        }

        if (down_flg)
        {
            this.transform.Rotate(new Vector3(0, 0, speed));

            now_rotate += speed;

            if (max_rotate <= now_rotate)
            {
                down_flg = false;
                now_rotate = 0;
                Invoke("DelayMethod", 0.25f);
            }
        }
    }

    //遅延処理
    private void DelayMethod()
    {
        rotate_flg = true;
    }
}
