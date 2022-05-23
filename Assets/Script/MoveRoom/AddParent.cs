using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParent : MonoBehaviour
{
    //RoomCollitionの変数を使う
    private RoomCollition room_collition;
    //BoxVariableの変数を使う
    private BoxVariable box_variable;

    //親オブジェクト
    private GameObject parent;

    private WallHit wall_hit;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject; //オブジェクトを探す

        GameObject obj = transform.parent.gameObject;//オブジェクトを探す
        box_variable = obj.GetComponent<BoxVariable>();//付いているスクリプトを取得

        wall_hit = GetComponent<WallHit>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score.score);
        if (box_variable.become_child == true)
        {
            //親
            GameObject parent = this.transform.parent.gameObject;

            //タグ変更
            parent.tag = "ActiveBox";

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

            // クォータニオン → オイラー角への変換
            Vector3 rotationAngles = parent.transform.rotation.eulerAngles;
            //角度の誤差修正
            if ((rotationAngles.z >= 170) && (rotationAngles.z <= 190))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
            }
            else if ((rotationAngles.z >= 80) && (rotationAngles.z <= 100))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
            }
            else if ((rotationAngles.z >= 260) && (rotationAngles.z <= 280))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
            }
            else if ((rotationAngles.z >= -10) && (rotationAngles.z <= 10))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
            }
            else if ((rotationAngles.z >= 350) && (rotationAngles.z <= 370))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360);
            }

            Destroy(wall_hit);

            //このスクリプトを削除
            Destroy(this);
        }
    }
}
