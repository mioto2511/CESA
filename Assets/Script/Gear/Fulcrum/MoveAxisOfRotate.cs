using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisOfRotate : MonoBehaviour
{
    public bool move_flg;

    public Vector3 axis_pos;

    //RotateRoomの変数を使う
    RotateRoom rotate_room;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = GameObject.Find("RotateRoom"); //オブジェクトを探す
        GameObject obj = GameObject.Find("Room"); //オブジェクトを探す
        rotate_room = obj.GetComponent<RotateRoom>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flg == true)
        {
            this.transform.position = axis_pos;

            move_flg = false;

            rotate_room.rotate_flg = true;
        }
    }
}
