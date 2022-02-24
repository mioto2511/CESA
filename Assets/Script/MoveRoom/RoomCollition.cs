using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollition : MonoBehaviour
{
    //RotateRoom変数を使う
    RotateRoom rotate_room;
    //ParentRoom変数を使う
    ParentRoom parent_room;

    //自身のtf
    Transform my_transform;

    //子になるフラグ
    public bool become_child = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("RotateRoom"); //オブジェクトを探す
        rotate_room = obj.GetComponent<RotateRoom>();　//付いているスクリプトを取得

        GameObject obj1 = GameObject.Find("Room"); //オブジェクトを探す
        parent_room = obj1.GetComponent<ParentRoom>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        my_transform = this.transform;

        if(parent_room.room_hit == true)
        {
            //位置の誤差修正
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            Vector3 my_pos = this.transform.position;

            my_pos.x = Mathf.Round(my_pos.x);     //四捨五入
            my_pos.y = Mathf.Round(my_pos.y);     //四捨五入

            this.transform.position = my_pos;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Room"))
        {
            
            if (rotate_room.rotate_flg == true)
            {
                Debug.Log(this);
                
            }
            //回転フラグを折る
            rotate_room.rotate_flg = false;

            //部屋同士があたった
            parent_room.room_hit = true;

            become_child = true;

            //設置した歯車を削除
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Gear");
            foreach (GameObject del in objects)
            {
                Destroy(del);
            }

            //位置の誤差修正
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            Vector3 my_pos = this.transform.position;

            my_pos.x = Mathf.Round(my_pos.x);     //四捨五入
            my_pos.y = Mathf.Round(my_pos.y);     //四捨五入

            this.transform.position = my_pos;
        }
    }
}
