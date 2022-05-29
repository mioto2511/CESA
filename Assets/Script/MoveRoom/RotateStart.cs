using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStart : MonoBehaviour
{
    //AutoPlayerMoveの変数を使う
    private AutoPlayerMove auto_player_move;
    //MoveAxisOfRotateの変数を使う
    private MoveAxisOfRotate move_axis;
    //Accelerationの変数を使う
    private Acceleration acceleration;

    //ボタンフラグ
    public bool botton_flg = true;

    private float deadzone = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj1 = GameObject.Find("AxisOfRotation"); //オブジェクトを探す
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();　//付いているスクリプトを取得

        GameObject obj2 = GameObject.Find("Player"); //オブジェクトを探す
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();　//付いているスクリプトを取得
        acceleration = obj2.GetComponent<Acceleration>();//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (botton_flg)
        {
            //StickEnter();
            if (Input.GetKeyDown("joystick button 0"))
            {
                //時間を等倍に
                Time.timeScale = 1;

                //ボタンを押せなくする
                botton_flg = false;

                //軸セット
                move_axis.move_flg = true;

                //プレイヤーを停止
                auto_player_move.move_flg = false;

                //加速不可能にする
                acceleration.button_flg = false;

                //歯車のコライダー削除
                GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = false;
                }
                objects = GameObject.FindGameObjectsWithTag("RGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = false;
                }

            }
        }
        
    }

    void StickEnter()
    {
        float lsh = Input.GetAxis("L_Stick_H");//横軸
        float lsv = Input.GetAxis("L_Stick_V");//縦軸

        //スティック入力がはいったら
        if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
        {
            //時間を等倍に
            Time.timeScale = 1;

            //ボタンを押せなくする
            botton_flg = false;

            //軸セット
            move_axis.move_flg = true;

            //プレイヤーを停止
            auto_player_move.move_flg = false;

            //加速不可能にする
            acceleration.button_flg = false;

            //歯車のコライダー削除
            GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
            foreach (GameObject num in objects)
            {
                var colliderTest = num.GetComponent<Collider2D>();
                colliderTest.enabled = false;
            }
            objects = GameObject.FindGameObjectsWithTag("RGear");
            foreach (GameObject num in objects)
            {
                var colliderTest = num.GetComponent<Collider2D>();
                colliderTest.enabled = false;
            }
        }
        //else
        //{
        //    //ボタンを押せなくする
        //    botton_flg = true;

        //    //軸セット
        //    move_axis.move_flg = false;

        //    //プレイヤーを停止
        //    auto_player_move.move_flg = true;

        //    //加速不可能にする
        //    acceleration.button_flg = true;

        //    //歯車のコライダー削除
        //    GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
        //    foreach (GameObject num in objects)
        //    {
        //        var colliderTest = num.GetComponent<Collider2D>();
        //        colliderTest.enabled = true;
        //    }
        //    objects = GameObject.FindGameObjectsWithTag("RGear");
        //    foreach (GameObject num in objects)
        //    {
        //        var colliderTest = num.GetComponent<Collider2D>();
        //        colliderTest.enabled = true;
        //    }
        //}

    }
}
