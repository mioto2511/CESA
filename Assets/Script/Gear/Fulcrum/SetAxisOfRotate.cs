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
    //RotateTestの変数を使う
    RightRotateTest rightrotate_test;
    //LeftRotateTestの変数を使う
    LeftRotateTest leftrotate_test;

    private int cunt = 0;

    private bool active = false;

    public bool collider_flg = true;

    //軸のコライダー
    private Collider2D collider;

    public bool check = false;

    private bool right = false;
    private bool left = false;

    //テストの初期位置保存用
    private Vector3 activebox_pos;

    private GameObject right_obj;
    private GameObject left_obj;

    //Vector3 box_pos;

    // Start is called before the first frame update
    void Start()
    {
        right_obj = transform.Find("RightTrigger").gameObject;
        rightrotate_test = right_obj.GetComponent<RightRotateTest>(); //スクリプトを取得

        left_obj = transform.Find("LeftTrigger").gameObject;
        leftrotate_test = left_obj.GetComponent<LeftRotateTest>(); //スクリプトを取得

        collider = this.GetComponent<Collider2D>();


        GameObject obj1 = GameObject.Find("AxisOfRotation"); //オブジェクトを探す
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();　//付いているスクリプトを取得

        GameObject obj2 = GameObject.Find("Room"); //オブジェクトを探す
        rotate_room = obj2.GetComponent<RotateRoom>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        //壁4つ以上に当たっている
        if (cunt >= 4)
        {
            //RoomのBoxに当たっている
            if (active)
            {
                //自身を取得
                Vector3 my_pos = this.transform.position;

                //リストに追加
                //move_axis.axis_poses[0] = my_pos;
                //move_axis.axis_poses.Add(my_pos);

                //Debug.Log(this.name);
                active = false;

                //支点を移動させる
                //move_axis.move_flg = true;

                //right = true;

                right_obj.transform.position = activebox_pos;
                left_obj.transform.position = activebox_pos;

                rightrotate_test.Move();
                leftrotate_test.Move();
            }


            //支点に移動させる
            //move_axis.axis_pos = my_pos;
        }

        if (rightrotate_test.box_hit == false)
        {
            if(right_obj.transform.position != this.transform.position)
            {
                Vector3 my_pos = this.transform.position;
                move_axis.axis_poses[0] = my_pos;
            }
            
        }
        if (leftrotate_test.box_hit == false)
        {
            if (right_obj.transform.position != this.transform.position)
            {
                Vector3 my_pos = this.transform.position;
                move_axis.axis_poses[1] = my_pos;
            }
                
        }

        //コライダーのON/OFF
        if (rotate_room.collider_flg)
        {
            collider.enabled = true;

            //rightrotate_test.ColliderSwith(1);
            //leftrotate_test.ColliderSwith(1);
        }
        else
        {
            collider.enabled = false;
            cunt = 0;
            //active = false;

            //rightrotate_test.ColliderSwith(0);
            //leftrotate_test.ColliderSwith(0);

            right_obj.transform.localPosition = new Vector3(0, 0, 0);
            left_obj.transform.localPosition = new Vector3(0, 0, 0);

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

            //軸の当たってるboxの座標
            activebox_pos = other.transform.position;
        }
    }
}
