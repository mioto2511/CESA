using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このスクリプトはいらない子です
public class ParentRoom : MonoBehaviour
{
    //部屋同士が当たったフラグ
    public bool room_hit = false;

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
        //ボタンを押すと回転
        if (rotate_room.rotate_flg == true)
        {
            transform.parent = GameObject.Find("RotateRoom").transform;
        }

        if(room_hit == true)
        {
            this.gameObject.transform.parent = null;
            room_hit = false;
        }

    }
}
