using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    public static RotateRoom instance;
    public int rotate_cnt = 0;

    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
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
    public bool right_rotate = false;
    public bool left_rotate = false;

    //部屋同士が当たったか
    public bool room_hit = false;

    private int child_cnt = 0;

    //自身のtf
    Transform my_transform;
    Vector3 my_rotate;

    //AutoPlayerMoveの変数を使う
    AutoPlayerMove auto_player_move;

    void Start()
    {
        GameObject obj2 = GameObject.Find("Player"); //オブジェクトを探す
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();　//付いているスクリプトを取得
    }

    void Update()
    {
        // transformを取得
        my_transform = this.transform;

        ////回転方向の変更
        //if (Input.GetKeyDown("joystick button 5"))//右
        //{
        //    right_rotate = true;
        //    left_rotate = false;
        //    Debug.Log("R");
        //}
        //else if (Input.GetKeyDown("joystick button 4"))//左
        //{
        //    left_rotate = true;
        //    right_rotate = false;
        //    Debug.Log("L");
        //}

        //部屋が当たった
        if (room_hit == true)
        {
            child_cnt++;

            if (child_cnt >= this.transform.childCount)
            {
                room_hit = false;
                child_cnt = 0;

                //回転方向の初期化
                left_rotate = false;
                right_rotate = false;

                //歯車のコライダーON
                GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = true;
                }
                objects = GameObject.FindGameObjectsWithTag("RGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = true;
                }

                //カーソルのタグ変更
                GameObject obj = GameObject.Find("SelectCursor"); //オブジェクトを探す
                obj.tag = "Cursor";

                //プレイヤーを起動
                auto_player_move.move_flg = true;
            }
            
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
