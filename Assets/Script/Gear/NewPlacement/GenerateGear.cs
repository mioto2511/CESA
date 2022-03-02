using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGear : MonoBehaviour
{
    //生成するオブジェクト
    public GameObject gear;

    //削除用
    BoxVariable box_variable;

    //CursorCollisionの変数を使う
    CursorCollision cursor_collision;
    //DeleteLocationの変数を使う
    DeleteLocation delete_location;

    private GameObject parent_obj;

    // Start is called before the first frame update
    void Start()
    {
        //スクリプトを取得
        cursor_collision = GetComponent<CursorCollision>();

        //GameObject obj = transform.parent.gameObject;
        //delete_location = obj.GetComponent<DeleteLocation>();

        GameObject obj = transform.parent.gameObject;
        box_variable = obj.GetComponent<BoxVariable>();
        //親を取得
        parent_obj = transform.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        //vector3に変換
        Vector3 pos = myTransform.position;

        if (Input.GetKeyDown("joystick button 0"))
        {
            if(cursor_collision.cursorhit == true)
            {
                //親にする
                var parent = parent_obj.transform;

                GameObject gear_obj =Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity,parent);
                //そのうち実数から変更（萩野直す）
                //スケール変更
                gear_obj.transform.localScale = new Vector3(2, 2, 0);
                //設置用のオブジェクトを削除
                box_variable.delete_flg = true;
            }
        }
    }
}
