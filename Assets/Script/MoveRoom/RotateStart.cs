using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class RotateStart : MonoBehaviour
{
    //AutoPlayerMoveの変数を使う
    private AutoPlayerMove auto_player_move;
    //MoveAxisOfRotateの変数を使う
    private MoveAxisOfRotate move_axis;
    //Accelerationの変数を使う
    private Acceleration acceleration;
    
    // プレイヤーがアクティブ状態になった時に使う
    private Material player_prt;
    private HitStop hit_stop;

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

        // 部屋を回すAbuttonを押したときのパーティクルのマテリアル
        GameObject prt = GameObject.Find("ParticleActive");
        player_prt = prt.GetComponent<Renderer>().material;

        GameObject obj3 = GameObject.Find("Main Camera");
        hit_stop = obj3.GetComponent<HitStop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (botton_flg)
        {
            //StickEnter();
            if (Input.GetKeyDown("joystick button 0"))
            {
                // Abuttonが押されたらplayerかParticleを出す
                SEManager.Instance.Play(SEPath.SE_023); // SE
                // Particleを発生
                player_prt.SetFloat("_alpha", 1);
                // HitStop
                hit_stop.hitstop_flg = true;
                hit_stop.time = 7;
                hit_stop.duration1 = 0.02f;
                hit_stop.magnitude1 = 0.3f;
                Debug.Log("RotationActive");

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
