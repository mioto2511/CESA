using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGear : MonoBehaviour
{
    [SerializeField, Tooltip("生成する歯車")]
    private GameObject gear;

    //削除用
    private BoxVariable box_variable;

    //CursorCollisionの変数を使う
    private CursorCollision cursor_collision;
    //DeleteLocationの変数を使う
    private DeleteLocation delete_location;

    //親
    private GameObject parent_obj;

    // Start is called before the first frame update
    void Start()
    {
        cursor_collision = GetComponent<CursorCollision>();//付いているスクリプトを取得

        GameObject obj = transform.parent.gameObject;//オブジェクトを探す
        box_variable = obj.GetComponent<BoxVariable>();//付いているスクリプトを取得

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

                GameObject gear_obj =Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity,parent);
                //そのうち実数から変更（萩野直す）
                //スケール変更
                gear_obj.transform.localScale = new Vector3(0.375f, 0.375f, 0);
                //設置用のオブジェクトを削除
                box_variable.delete_flg = true;
            }
        }
    }
}
