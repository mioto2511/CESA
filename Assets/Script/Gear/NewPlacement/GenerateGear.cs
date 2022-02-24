using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGear : MonoBehaviour
{
    //生成するオブジェクト
    public GameObject gear;

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

        GameObject obj = transform.parent.gameObject;
        delete_location = obj.GetComponent<DeleteLocation>();

        //親を取得
        parent_obj = transform.parent.gameObject;
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

                Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity,parent);

                //設置用のオブジェクトを削除
                delete_location.delete_flg = true;
            }
        }
    }
}
