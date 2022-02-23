 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kari : MonoBehaviour
{
    Transform my_transform;
    Vector3 my_pos;

    //RotateRoom変数を使う
    RotateRoom rotate_room;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("RotateRoom"); //オブジェクトを探す
        rotate_room = obj.GetComponent<RotateRoom>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        my_transform = this.transform;

        my_pos = my_transform.position;

        //ボタンを押すと回転
        if (Input.GetKeyDown("joystick button 0"))
        {
            my_pos.x = 1;
            my_pos.y = 1;
            rotate_room.rotate_flg = true;
        }
        //ボタンを押すと回転
        else if (Input.GetKeyDown("joystick button 1"))
        {
            my_pos.x = -1;
            my_pos.y = -1;
            rotate_room.rotate_flg = true;
        }

        my_transform.position = my_pos;
    }
}
