using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisOfRotate : MonoBehaviour
{
    public bool move_flg;

    public Vector3 axis_pos;

    //RotateRoomの変数を使う
    RotateRoom rotate_room;
    //AutoPlayerMoveの変数を使う
    AutoPlayerMove auto_player_move;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = GameObject.Find("RotateRoom"); //オブジェクトを探す
        GameObject obj = GameObject.Find("Room"); //オブジェクトを探す
        rotate_room = obj.GetComponent<RotateRoom>();　//付いているスクリプトを取得

        GameObject obj2 = GameObject.Find("Player"); //オブジェクトを探す
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flg == true)
        {
            this.transform.position = axis_pos;

            move_flg = false;

            //プレイヤーを停止
            auto_player_move.move_flg = false;

            //回転開始
            rotate_room.rotate_flg = true;

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
