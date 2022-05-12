using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRotate : MonoBehaviour
{
    private bool rotate_flg = true;

    private bool up_flg = false;
    private bool down_flg = false;

    private float max_rotate = 45f;
    private float hight_max_rotate = 180f;
    private float now_rotate = 0;

    [Header("回転速度")] public float speed = 0.1f;

    [Header("倍率")] public float magnification = 4f;

    [Header("デットゾーン")] public float deadzone = 0.5f;

    private int count = 1;

    private GameObject trigger_obj;

    //ステックの開始地点
    private float start_radian = 0;

    //ステックの前回角度
    private float old_radian = 0;

    //初期位置フラグ
    private bool initial_flg = true;

    void Start()
    {
        trigger_obj = GameObject.Find("Trigger"); // オブジェクトを探す
    }

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

                        trigger_obj.SetActive(false);
                    }
                    else if (now_radian <= -90)
                    {
                        down_flg = true;

                        rotate_flg = false;

                        initial_flg = true;

                        trigger_obj.SetActive(false);
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
        //Debug.Log(count);
        if (up_flg)
        {
            if(count <= 1)
            {
                this.transform.Rotate(new Vector3(0, 0, speed*magnification));

                now_rotate += speed* magnification;

                if (hight_max_rotate <= now_rotate)
                {
                    count = 6;
                    up_flg = false;
                    now_rotate = 0;
                    Invoke("DelayMethod", 0.25f);
                }
            }
            else
            {
                this.transform.Rotate(new Vector3(0, 0, -speed));

                now_rotate += -speed;

                if (-max_rotate >= now_rotate)
                {
                    count -= 1;
                    up_flg = false;
                    now_rotate = 0;
                    Invoke("DelayMethod", 0.25f);
                }
            }
            
        }

        if (down_flg)
        {
            if (count >= 5)
            {
                this.transform.Rotate(new Vector3(0, 0, -speed * magnification));

                now_rotate += -speed * magnification;

                if (-hight_max_rotate >= now_rotate)
                {
                    count = 1;
                    down_flg = false;
                    now_rotate = 0;
                    Invoke("DelayMethod", 0.25f);
                }
            }
            else
            {
                this.transform.Rotate(new Vector3(0, 0, speed));

                now_rotate += speed;

                if (max_rotate <= now_rotate)
                {
                    count += 1;
                    down_flg = false;
                    now_rotate = 0;
                    Invoke("DelayMethod", 0.25f);
                }
            }
            
        }
    }

    //遅延処理
    private void DelayMethod()
    {
        rotate_flg = true;
        trigger_obj.SetActive(true);
    }
}
