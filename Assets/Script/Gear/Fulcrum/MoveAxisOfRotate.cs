using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisOfRotate : MonoBehaviour
{
    public bool move_flg;

    public List<Vector3> axis_poses = new List<Vector3>();// リスト
    public Vector3 axis_pos;

    //RotateRoomの変数を使う
    RotateRoom rotate_room;
    //AutoPlayerMoveの変数を使う
    AutoPlayerMove auto_player_move;

    public bool chang_axis = false;
    private int axis_num = 0;

    public bool delete_list = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Room"); //オブジェクトを探す
        rotate_room = obj.GetComponent<RotateRoom>();　//付いているスクリプトを取得

        GameObject obj2 = GameObject.Find("Player"); //オブジェクトを探す
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flg)
        {
            //Debug.Log(string.Join(",", axis_poses));
            this.transform.position = axis_poses[0];

            //if(axis_poses.Count < 2)
            //{
            //    Vector3 pos = axis_poses[0];
            //    axis_poses.Add(pos);
            //}

            move_flg = false;

            //プレイヤーを停止
            auto_player_move.move_flg = false;

            //回転開始
            rotate_room.rotate_flg = true;

            rotate_room.collider_flg = false;

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

        if (chang_axis)
        {
            if(axis_num == 0)
            {
                if (axis_poses.Count >= 2)
                {
                    this.transform.position = axis_poses[1];
                    axis_num = 1;
                }
                
            }
            else if (axis_num == 1)
            {
                this.transform.position = axis_poses[0];
                axis_num = 0;
            }

            chang_axis = false;
        }

        if (delete_list)
        {
            delete_list = false;

            axis_poses.Clear();
        }
    }
}
