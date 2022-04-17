using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisOfRotate : MonoBehaviour
{
    public bool move_flg;

    //public List<Vector3> axis_poses = new List<Vector3>();// リスト
    public Vector3[] axis_poses;

    public Vector3 axis_pos;

    //RotateRoomの変数を使う
    RotateRoom rotate_room;
    

    public bool chang_axis = false;
    private int axis_num = 0;

    public bool delete_list = false;

    // Start is called before the first frame update
    void Start()
    {
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


            //if (axis_poses.Count < 2)
            //{
            //    Vector3 pos = axis_poses[0];
            //    //axis_poses[1] = axis_poses[0];
            //    axis_poses.Add(pos);
            //}


            //GameObject Lobject = GameObject.FindGameObjectsWithTag("LGear");
            //GameObject Robject = GameObject.FindGameObjectsWithTag("LGear");
            //if(object == R)
            //{
            //    axis_poses[0] = objectpos
            //}
            //if(object == L)
            //{
            //    axis_poses[1] = objectpos
            //}
            this.transform.position = axis_poses[0];

            move_flg = false;

            

            //回転開始
            rotate_room.rotate_flg = true;

            rotate_room.collider_flg = false;

            

        }

        //if (chang_axis)
        //{
        //    if(axis_num == 0)
        //    {
        //        if (axis_poses.Count >= 2)
        //        {
        //            this.transform.position = axis_poses[1];
        //            axis_num = 1;
        //        }

        //    }
        //    else if (axis_num == 1)
        //    {
        //        this.transform.position = axis_poses[0];
        //        axis_num = 0;
        //    }

        //    chang_axis = false;
        //}

        if (delete_list)
        {
            delete_list = false;

            //axis_poses.Clear();
            for (int i = 0; i < axis_poses.Length; i++)
            {
                axis_poses[i] = new Vector3(0, 0, 0);
            }
        }
    }

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
