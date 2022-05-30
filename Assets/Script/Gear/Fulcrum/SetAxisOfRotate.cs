using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAxisOfRotate : MonoBehaviour
{
    //MoveAxisOfRotateの変数を使う
    MoveAxisOfRotate move_axis;
    //RotateRoomの変数を使う
    RotateRoom rotate_room;
    //RotateTestの変数を使う
    RightRotateTest rightrotate_test;
    //LeftRotateTestの変数を使う
    LeftRotateTest leftrotate_test;

    private int count = 0;

    private bool active = false;

    public bool collider_flg = true;

    //軸のコライダー
    private Collider2D my_collider;

    //テストの初期位置保存用
    private Vector3 activebox_pos;

    private GameObject right_obj;
    private GameObject left_obj;

    private bool hit_flg = true;
    //private int startcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //自身のコライダー
        my_collider = this.GetComponent<Collider2D>();

        right_obj = transform.Find("RightTrigger").gameObject;//オブジェクトを探す
        rightrotate_test = right_obj.GetComponent<RightRotateTest>(); //スクリプトを取得

        left_obj = transform.Find("LeftTrigger").gameObject;//オブジェクトを探す
        leftrotate_test = left_obj.GetComponent<LeftRotateTest>(); //スクリプトを取得

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //オブジェクトを探す
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();　//付いているスクリプトを取得

        GameObject obj2 = GameObject.Find("Room"); //オブジェクトを探す
        rotate_room = obj2.GetComponent<RotateRoom>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        //壁4つ以上に当たっている
        if (count >= 4)
        {
            //RoomのBoxに当たっている
            if (active)
            {
                //自身を取得
                Vector3 my_pos = this.transform.position;

                active = false;

                hit_flg = false;

                //支点に触れているBoxの位置にテストオブジェクト配置
                right_obj.transform.position = activebox_pos;
                left_obj.transform.position = activebox_pos;

                //回転テスト
                rightrotate_test.Move();
                leftrotate_test.Move();
            }
        }

        //テストオブジェクトがBoxに触れてないなら配列に代入
        if (rightrotate_test.box_hit == false)
        {
            if(right_obj.transform.position != this.transform.position)
            {
                Vector3 my_pos = this.transform.position;
                move_axis.axis_poses[0] = my_pos;
            }          
        }
        if (leftrotate_test.box_hit == false)
        {
            if (right_obj.transform.position != this.transform.position)
            {
                Vector3 my_pos = this.transform.position;
                move_axis.axis_poses[1] = my_pos;
            }                
        }

        //コライダーのON/OFF
        if (rotate_room.collider_flg)
        {
            hit_flg = true;
            //コライダーON
            my_collider.enabled = true;
        }
        else
        {
            //コライダーOFF
            my_collider.enabled = false;

            //カウント初期化
            count = 0;

            //テストオブジェクト位置初期化
            right_obj.transform.localPosition = new Vector3(0, 0, 0);
            left_obj.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            count++;
        }

        //if (other.gameObject.CompareTag("ActiveBox"))
        //{
        //    Debug.Log(gameObject.name);
        //    active = true;

        //    //軸の当たってるboxの座標
        //    activebox_pos = other.transform.position;
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hit_flg)
        {
            if (collision.gameObject.CompareTag("ActiveBox"))
            {
                //Debug.Log(gameObject.name);
                active = true;

                //軸の当たってるboxの座標
                activebox_pos = collision.transform.position;
            }
        }
    }
}
