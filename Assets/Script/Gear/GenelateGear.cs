using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenelateGear : MonoBehaviour
{
    public GameObject gear;

    GameObject cursor;

    //生成フラグ
    public bool GenerateFlg = true;

    //CursorCollisionの変数を使う
    CursorCollision cursor_collision;

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        //vector3に変換
        Vector3 pos = myTransform.position;

        //変数を使える用にする
        cursor_collision = GetComponent<CursorCollision>();

        //カーソルを見つける
        cursor = GameObject.Find("Cursor");

        if (Input.GetKeyDown("joystick button 0"))
        {
            //ほかの歯車に当たってないなら
            if(cursor_collision.cursorhit == false)
            {
                if (GenerateFlg == true)
                {
                    Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                }
            }
        }
    }
}
