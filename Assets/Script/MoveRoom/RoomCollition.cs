using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollition : MonoBehaviour
{
    //RotateRoom変数を使う
    private RotateRoom root_room;
    //BoxVariable
    private BoxVariable box_variable;

    //自身のtf
    private Transform my_transform;

    //親と親の親
    private GameObject parent;
    private GameObject root;


    // Start is called before the first frame update
    void Start()
    {
        root = this.transform.parent.parent.gameObject; //オブジェクトを探す
        root_room = root.GetComponent<RotateRoom>(); //付いているスクリプトを取得

        parent = this.transform.parent.gameObject; //オブジェクトを探す
        box_variable = parent.GetComponent<BoxVariable>();//付いているスクリプトを取得

        //位置の誤差修正
        ErrorCorrection();

        //座標取得
        box_variable.box_pos = parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        my_transform = this.transform;

        //自身以外の部屋が当たった場合
        if (root_room.room_hit == true)
        {
            //位置の誤差修正
            ErrorCorrection();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //回転フラグを折る
            //root_room.rotate_flg = false;

            //部屋同士があたった
            root_room.room_hit = true;
            Debug.Log("hit");
            

            ////再び設置できるようにする
            //box_variable.location_flg = true;

            ////Debug.Log("hit"+this);

            ////接続されてるか？
            ////当たった先の変数をいじる
            ////GameObject collision_parent = collision.transform.parent.gameObject;
            ////BoxVariable collision_box_variable = collision_parent.GetComponent<BoxVariable>(); //付いているスクリプトを取得
            ////collision_box_variable.become_child = true;



            ////設置した歯車を削除
            //GameObject[] objects = GameObject.FindGameObjectsWithTag("Gear");
            //foreach (GameObject del in objects)
            //{
            //    Destroy(del);
            //}

            //位置の誤差修正
            ErrorCorrection();
        }
    }

    //位置の誤差修正
    void ErrorCorrection()
    {
        //位置の誤差修正
        Vector3 root_pos = root.transform.position;
        root_pos.x = Mathf.Round(root_pos.x);     //四捨五入
        root_pos.y = Mathf.Round(root_pos.y);     //四捨五入
        root.transform.position = root_pos;

        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = root.transform.rotation.eulerAngles;

        //Debug.Log(root.transform.rotation.z);
        //parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(parent.transform.rotation.z));

        //角度の誤差修正
        if ((rotationAngles.z >= 178) && (rotationAngles.z <= 182))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
        }
        else if ((rotationAngles.z >= 88) && (rotationAngles.z <= 92))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
        }
        else if ((rotationAngles.z >= 268) && (rotationAngles.z <= 272))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
        }
        else if ((rotationAngles.z >= -2) && (rotationAngles.z <= 2))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
        }
        else if ((rotationAngles.z >= 358) && (rotationAngles.z <= 362))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360);
        }
        //root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(root.transform.rotation.z));

        //位置の誤差修正
        Vector3 parent_pos = parent.transform.position;
        parent_pos.x = Mathf.Round(parent_pos.x);     //四捨五入
        parent_pos.y = Mathf.Round(parent_pos.y);     //四捨五入
        parent.transform.position = parent_pos;

        //Vector3 parent_lpos = parent.transform.localPosition;
        //parent_lpos.x = Mathf.Round(parent_lpos.x);     //四捨五入
        //parent_lpos.y = Mathf.Round(parent_lpos.y);     //四捨五入
        //parent.transform.localPosition = parent_lpos;


        Vector3 my_pos = this.transform.position;
        my_pos.x = my_pos.x * 100000;
        my_pos.y = my_pos.y * 100000;

        my_pos.x = Mathf.Floor(my_pos.x) / 100000;
        my_pos.y = Mathf.Floor(my_pos.y) / 100000;

        this.transform.position = my_pos;
    }
}