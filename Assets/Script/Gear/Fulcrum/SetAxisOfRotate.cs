using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAxisOfRotate : MonoBehaviour
{
    //GearCollisionの変数を使う
    //GearCollision gear_collision;
    //MoveAxisOfRotateの変数を使う
    MoveAxisOfRotate move_axis;
    //RotateRoomの変数を使う
    RotateRoom rotate_room;

    private int cunt = 0;

    private bool active = false;

    public bool collider_flg = true;


    Collider2D collider;

    //Vector3 box_pos;

    // Start is called before the first frame update
    void Start()
    {
        //gear_collision = GetComponent<GearCollision>(); //スクリプトを取得

        collider = this.GetComponent<Collider2D>();


        GameObject obj1 = GameObject.Find("AxisOfRotation"); //オブジェクトを探す
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();　//付いているスクリプトを取得

        GameObject obj2 = GameObject.Find("Room"); //オブジェクトを探す
        rotate_room = obj2.GetComponent<RotateRoom>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        //if(gear_collision.gear_hit == true)
        //{
            
        //}
        //壁4つに当たっている
        if (cunt == 4)
        {
            //RoomのBoxに当たっている
            if (active)
            {
                //自身を取得
                Vector3 my_pos = this.transform.position;

                //リストに追加
                move_axis.axis_poses.Add(my_pos);

                //右下
                //if(my_pos.x > box_pos.x && my_pos.y < box_pos.y)
                //{
                //    //Rayの作成
                //    Ray ray = new Ray(transform.position, new Vector3(-1, 0,0));

                //    //Rayが当たったオブジェクトの情報を入れる箱
                //    RaycastHit2D hit;

                //    //Rayの飛ばせる距離
                //    int distance = 6;
                //    if (Physics2D.Raycast((Vector2)ray, out hit, distance))
                //    {
                //        //Rayが当たったオブジェクトのtagがPlayerだったら
                //        if (hit.collider.tag == "FulcrumGear")
                //            Debug.Log("RayがPlayerに当たった");
                //    }
                //    right_flg = true;
                //}
                //else if (my_pos.x < box_pos.x && my_pos.y < box_pos.y)
                //{
                //    left_flg = true;
                //}
                //if (my_pos.x > box_pos.x && my_pos.y < box_pos.y)
                //{
                //    right_flg = true;
                //}
                //if (my_pos.x > box_pos.x && my_pos.y < box_pos.y)
                //{
                //    right_flg = true;
                //}

                Debug.Log(this.name);
                active = false;

                //支点を移動させる
                //move_axis.move_flg = true;
            }


            //支点に移動させる
            //move_axis.axis_pos = my_pos;

            //gear_collision.gear_hit = false;
        }

        //コライダーのON/OFF
        if (rotate_room.collider_flg)
        {
            collider.enabled = true;
            
        }
        else
        {
            collider.enabled = false;
            cunt = 0;
            active = false;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            cunt++;
        }

        if (other.gameObject.CompareTag("ActiveBox"))
        {
            active = true;

            //box_pos = other.transform.position; 
        }
    }
}
