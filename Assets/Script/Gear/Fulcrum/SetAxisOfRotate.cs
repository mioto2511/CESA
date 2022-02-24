using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAxisOfRotate : MonoBehaviour
{
    //GearCollisionの変数を使う
    GearCollision gear_collision;
    //MoveAxisOfRotate
    MoveAxisOfRotate move_axis;

    // Start is called before the first frame update
    void Start()
    {
        gear_collision = GetComponent<GearCollision>(); //スクリプトを取得

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //オブジェクトを探す
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if(gear_collision.gear_hit == true)
        {
            //自身を取得
            Vector3 my_pos = this.transform.position;

            //支点に移動させる
            move_axis.axis_pos = my_pos;

            //支点を移動させる
            move_axis.move_flg = true;

            gear_collision.gear_hit = false;
        }
    }
}
