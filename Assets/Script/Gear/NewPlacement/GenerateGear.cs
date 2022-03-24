using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGear : MonoBehaviour
{
    [SerializeField, Tooltip("生成する歯車")]
    private GameObject gear;

    //削除用
    private BoxVariable box_variable;

    //SelectCursorCollisionの変数を使う
    private SelectCursorCollision select_cursor_collision;
    //DeleteLocationの変数を使う
    private DeleteLocation delete_location;
    //RotateRoomの変数を使う
    private RotateRoom rotate_room;

    //親
    private GameObject parent_obj;
    private GameObject root_obj;

    // Start is called before the first frame update
    void Start()
    {
        //親を取得
        parent_obj = transform.parent.gameObject;
        root_obj = transform.root.gameObject;

        select_cursor_collision = GetComponent<SelectCursorCollision>();//付いているスクリプトを取得

        //GameObject obj = transform.parent.gameObject;//オブジェクトを探す
        box_variable = parent_obj.GetComponent<BoxVariable>();//付いているスクリプトを取得

        rotate_room = root_obj.GetComponent<RotateRoom>();//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        //vector3に変換
        Vector3 pos = myTransform.position;

        if (Input.GetKeyDown("joystick button 5"))//右
        {
            if(select_cursor_collision.cursor_hit == true)
            {
                //右回転
                rotate_room.right_rotate = true;

                //親にする
                var parent = parent_obj.transform;

                GameObject gear_obj =Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity,parent);
                //そのうち実数から変更（萩野直す）
                //スケール変更
                gear_obj.transform.localScale = new Vector3(0.0359f, 0.0359f, 0);
                //設置用のオブジェクトを削除
                box_variable.delete_flg = true;
            }
        }
        else if (Input.GetKeyDown("joystick button 4"))//左
        {
            if (select_cursor_collision.cursor_hit == true)
            {
                //右回転
                rotate_room.left_rotate = true;

                //親にする
                var parent = parent_obj.transform;

                GameObject gear_obj = Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity, parent);
                //そのうち実数から変更（萩野直す）
                //スケール変更
                gear_obj.transform.localScale = new Vector3(0.0359f, 0.0359f, 0);
                //設置用のオブジェクトを削除
                box_variable.delete_flg = true;
            }
        }
    }
}
