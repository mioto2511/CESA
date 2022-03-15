using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParent : MonoBehaviour
{
    //RoomCollitionの変数を使う
    private RoomCollition room_collition;
    //BoxVariableの変数を使う
    private BoxVariable box_variable;

    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject; //オブジェクトを探す

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
                

                //ErrorCorrection();
                box_variable.become_child = false;
            }

            //このスクリプトを削除
            Destroy(this);
        }
    }

    //位置の誤差修正
    //void ErrorCorrection()
    //{
        
    //    // クォータニオン → オイラー角への変換
    //    Vector3 rotationAngles = parent.transform.rotation.eulerAngles;

    //    Debug.Log(rotationAngles.z);
    //    //Debug.Log(root.transform.rotation.z);
    //    //parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(parent.transform.rotation.z));

    //    //角度の誤差修正
    //    if ((rotationAngles.z >= 178) && (rotationAngles.z <= 182))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
    //    }
    //    else if ((rotationAngles.z >= 88) && (rotationAngles.z <= 92))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
    //    }
    //    else if ((rotationAngles.z >= 268) && (rotationAngles.z <= 272))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
    //    }
    //    else if ((rotationAngles.z >= -2) && (rotationAngles.z <= 2))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
    //    }
    //    else if ((rotationAngles.z >= 358) && (rotationAngles.z <= 362))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360);
    //    }
    //    //root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(root.transform.rotation.z));

    //    //位置の誤差修正
    //    Vector3 my_pos = parent.transform.position;
    //    my_pos.x = Mathf.Round(my_pos.x);     //四捨五入
    //    my_pos.y = Mathf.Round(my_pos.y);     //四捨五入
    //    parent.transform.position = my_pos;
    //}
}
