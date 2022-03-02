using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParent : MonoBehaviour
{
    //RoomCollitionの変数を使う
    private RoomCollition room_collition;
    //BoxVariableの変数を使う
    private BoxVariable box_variable;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = transform.parent.gameObject;//オブジェクトを探す
        box_variable = obj.GetComponent<BoxVariable>();//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (box_variable.become_child == true)
        {
            //親
            GameObject parent = this.transform.parent.gameObject;

            //Debug.Log("become"+parent);

            //親の親をRoomにする
            parent.transform.parent = GameObject.Find("Room").transform;

            //スクリプトを追加
            gameObject.AddComponent<RoomCollition>();

            //壁全てにスクリプトを追加するためのカウント
            box_variable.child_cnt++;

            //4つの目の壁の時フラグを折る
            if (box_variable.child_cnt >= 4)
            {
                box_variable.become_child = false;
            }

            //このスクリプトを削除
            Destroy(this);
        }
    }
}
