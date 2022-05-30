using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

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

    Vector3 save_pos;

    Transform tf;


    private void Awake()
    {
        save_pos = this.transform.localPosition;

        Debug.Log(save_pos);
    }

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
        LocalErrorCorrection();

        // transformを取得
        my_transform = this.transform;

        tf = this.transform;
        save_pos = tf.localPosition;

        //Debug.Log(save_pos);
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
            //Debug.Log("hit");


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
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Box"))
    //    {
    //        //回転フラグを折る
    //        //root_room.rotate_flg = false;

    //        //部屋同士があたった
    //        root_room.room_hit = true;

    //        //位置の誤差修正
    //        ErrorCorrection();
    //    }
    //}

    //位置の誤差修正
    void ErrorCorrection()
    {
        //Room位置の誤差修正
        Vector3 root_pos = root.transform.position;
        root_pos.x = Mathf.Round(root_pos.x);     //四捨五入
        root_pos.y = Mathf.Round(root_pos.y);     //四捨五入
        root.transform.position = root_pos;

        // クォータニオン → オイラー角への変換
        Vector3 rotationAngles = root.transform.rotation.eulerAngles;

        //角度の誤差修正
        if ((rotationAngles.z >= 170) && (rotationAngles.z <= 190))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
        }
        else if ((rotationAngles.z >= 80) && (rotationAngles.z <= 100))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
        }
        else if ((rotationAngles.z >= 260) && (rotationAngles.z <= 280))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
        }
        else if ((rotationAngles.z >= -10) && (rotationAngles.z <= 10))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
        }
        else if ((rotationAngles.z >= 350) && (rotationAngles.z <= 370))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360);
        }

        //親の位置の誤差修正
        Vector3 parent_pos = parent.transform.position;
        parent_pos.x = Mathf.Round(parent_pos.x);     //四捨五入
        parent_pos.y = Mathf.Round(parent_pos.y);     //四捨五入
        parent.transform.position = parent_pos;

        //Vector3 parent_lpos = parent.transform.localPosition;
        //parent_lpos.x = Mathf.Round(parent_lpos.x);     //四捨五入
        //parent_lpos.y = Mathf.Round(parent_lpos.y);     //四捨五入
        //parent.transform.localPosition = parent_lpos;

        //壁の位置の誤差修正
        //Vector3 my_pos = this.transform.position;
        //my_pos.x = my_pos.x * 100000;
        //my_pos.y = my_pos.y * 100000;

        //my_pos.x = Mathf.Floor(my_pos.x) / 100000;
        //my_pos.y = Mathf.Floor(my_pos.y) / 100000;

        //this.transform.position = my_pos;
    }
    void LocalErrorCorrection()
    {
        Vector3 pos = this.transform.localPosition;

        pos = save_pos;



        if ((pos.y < 0.0001) && (pos.y > -0.0001))
        {
            pos.y = 0;
        }
        if ((pos.x < 0.0001) && (pos.x > -0.0001))
        {
            pos.x = 0;
        }

        this.transform.localPosition = pos;

        //my_pos.x = Mathf.Floor(my_pos.x) / 100000;
        //my_pos.y = Mathf.Floor(my_pos.y) / 100000;

        //this.transform.position = my_pos;
    }
}