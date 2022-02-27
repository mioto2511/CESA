using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollition : MonoBehaviour
{
    //RotateRoom変数を使う
    RotateRoom root_room;
    //BoxVariable
    BoxVariable box_variable;

    //自身のtf
    Transform my_transform;

    GameObject parent;
    GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        root = this.transform.parent.parent.gameObject; //オブジェクトを探す
        //root = GameObject.Find("Room");
        root_room = root.GetComponent<RotateRoom>(); //付いているスクリプトを取得

        parent = this.transform.parent.gameObject; //オブジェクトを探す
        box_variable = parent.GetComponent<BoxVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        my_transform = this.transform;

        //Debug.Log(root.transform.rotation.z);

        if(root != null)
        {
            
        }

        if (root_room.room_hit == true)
        {
            //位置の誤差修正
            ErrorCorrection();
            //root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(root.transform.rotation.z));
            //if((root.transform.rotation.z >= -1.01f) &&(root.transform.rotation.z <= -0.98f))
            //{
            //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -1);
            //}

            //Vector3 my_pos = parent.transform.position;
            //my_pos.x = Mathf.Round(my_pos.x);     //四捨五入
            //my_pos.y = Mathf.Round(my_pos.y);     //四捨五入
            //parent.transform.position = my_pos;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Room"))
        {
            //回転フラグを折る
            root_room.rotate_flg = false;

            //部屋同士があたった
            root_room.room_hit = true;

            //Debug.Log("hit"+this);

            //接続されてるか？
            //当たった先の変数をいじる
            //GameObject collision_parent = collision.transform.parent.gameObject;
            //BoxVariable collision_box_variable = collision_parent.GetComponent<BoxVariable>(); //付いているスクリプトを取得
            //collision_box_variable.become_child = true;

            

            //設置した歯車を削除
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Gear");
            foreach (GameObject del in objects)
            {
                Destroy(del);
            }

            //位置の誤差修正
            ErrorCorrection();

            
            ////root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(root.transform.rotation.z));


            //Vector3 my_pos = parent.transform.position;
            //my_pos.x = Mathf.Round(my_pos.x);     //四捨五入
            //my_pos.y = Mathf.Round(my_pos.y);     //四捨五入
            //parent.transform.position = my_pos;
            //Debug.Log(root.transform.rotation.z);
        }
    }

    //位置の誤差修正
    void ErrorCorrection()
    {
        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(parent.transform.rotation.z));
        //if ((root.transform.rotation.z >= -1.01f) && (root.transform.rotation.z <= -0.98f))
        //{
        //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
        //}
        //else if ((root.transform.rotation.z >= -0.51f) && (root.transform.rotation.z <= -0.48f))
        //{
        //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
        //}
        //else if ((root.transform.rotation.z <= 1.01f) && (root.transform.rotation.z >= 0.98f))
        //{
        //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -180);
        //}
        //else if ((root.transform.rotation.z <= 0.51f) && (root.transform.rotation.z >= 0.48f))
        //{
        //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90);
        //}
        //root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        Vector3 my_pos = parent.transform.position;
        my_pos.x = Mathf.Round(my_pos.x);     //四捨五入
        my_pos.y = Mathf.Round(my_pos.y);     //四捨五入
        parent.transform.position = my_pos;
    }
}