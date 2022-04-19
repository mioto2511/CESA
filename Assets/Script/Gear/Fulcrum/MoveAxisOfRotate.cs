using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisOfRotate : MonoBehaviour
{
    public bool move_flg;

    //public List<Vector3> axis_poses = new List<Vector3>();// リスト
    public Vector3[] axis_poses;

    //RotateRoomの変数を使う
    RotateRoom rotate_room;

    // Start is called before the first frame update
    void Start()
    {
        //配列初期化
        axis_poses = new Vector3[2];

        GameObject obj = GameObject.Find("Room"); //オブジェクトを探す
        rotate_room = obj.GetComponent<RotateRoom>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flg)
        {
            Debug.Log(string.Join(",", axis_poses));

            move_flg = false;

            //回転開始
            rotate_room.rotate_flg = true;

            //支点のコライダーOFF
            rotate_room.collider_flg = false;
        }
    }

    //配列中身削除
    public void Delete()
    {
        for (int i = 0; i < axis_poses.Length; i++)
        {
            axis_poses[i] = new Vector3(0, 0, 0);
        }
    }

    //Axisを支点にセット
    public void SetAxis(int id)
    {
        if(id == 0)
        {
            //右
            this.transform.position = axis_poses[0];
        }
        else if(id == 1)
        {
            //左
            this.transform.position = axis_poses[1];
        }
    }
}
