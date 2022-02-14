using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTransparentGear : MonoBehaviour
{
    //生成するオブジェクト
    public GameObject TransparentGear;
    public GameObject CursorGear;

    //CursorColitionの変数を使う
    CursorColition cursor_colition;
    //MoveCursor変数を使う
    MoveCursor move_cursor;

    //生成フラグ
    public bool generateflg = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("SelectCursor"); //オブジェクトを探す
        move_cursor = obj.GetComponent<MoveCursor>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        //変数を使える用にする
        cursor_colition = GetComponent<CursorColition>();

        // transformを取得
        Transform myTransform = this.transform;

        //vector3に変換
        Vector3 pos = myTransform.position;

        //親にする
        var parent = this.transform;

        //ボタンを押すと周りに生成
        if (Input.GetKeyDown("joystick button 0"))
        {
            if(cursor_colition.cursorhit == true)
            {
                if (generateflg == true)
                {
                    //上下左右に生成
                    Instantiate(TransparentGear, new Vector3(pos.x + 1.0F, pos.y, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x, pos.y + 1.0F, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x - 1.0F, pos.y, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x, pos.y - 1.0F, 0), Quaternion.identity, parent);
                    //斜めに生成
                    Instantiate(TransparentGear, new Vector3(pos.x + 0.7F, pos.y + 0.7F, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x + 0.7F, pos.y - 0.7F, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x - 0.7F, pos.y + 0.7F, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x - 0.7F, pos.y - 0.7F, 0), Quaternion.identity, parent);
                    //カーソル生成
                    Instantiate(CursorGear, new Vector3(pos.x, pos.y, 0), Quaternion.identity, parent);

                    //生成をフラグを折る
                    generateflg = false;

                    //カーソルを動かなくする
                    move_cursor.moveflg = false;
                }
            }
            
        }
    }
}
