using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStart : MonoBehaviour
{
    //MoveCursor
    private MoveCursor move_cursor;
    //CursorCollisionの変数を使う
    private CursorCollision cursor_colition;
    //MoveAxisOfRotate
    MoveAxisOfRotate move_axis;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = GameObject.Find("SelectCursor"); //オブジェクトを探す
        //move_cursor = obj.GetComponent<MoveCursor>();　//付いているスクリプトを取得

        cursor_colition = GetComponent<CursorCollision>();　//付いているスクリプトを取得

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //オブジェクトを探す
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            if (cursor_colition.cursor_hit)
            {
                if (this.transform.tag == "ActiveBox")
                {
                    move_axis.move_flg = true;

                    GameObject cursor = GameObject.Find("SelectCursor"); //オブジェクトを探す
                    cursor.SetActive(false);
                }
            }
        }
    }
}
