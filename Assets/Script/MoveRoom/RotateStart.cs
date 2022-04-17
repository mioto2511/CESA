using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStart : MonoBehaviour
{
    //MoveCursor
    //private MoveCursor move_cursor;
    //CursorCollisionの変数を使う
    //private CursorCollision cursor_colition;
    //AutoPlayerMoveの変数を使う
    private AutoPlayerMove auto_player_move;
    //MoveAxisOfRotate
    private MoveAxisOfRotate move_axis;

    public bool botton_flg = true;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = GameObject.Find("SelectCursor"); //オブジェクトを探す
        //move_cursor = obj.GetComponent<MoveCursor>();　//付いているスクリプトを取得

        //cursor_colition = GetComponent<CursorCollision>();　//付いているスクリプトを取得

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //オブジェクトを探す
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();　//付いているスクリプトを取得

        GameObject obj2 = GameObject.Find("Player"); //オブジェクトを探す
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            if (botton_flg)
            {
                //if (this.transform.tag == "ActiveBox")
                //{

                //}
                botton_flg = false;
                //軸セット
                move_axis.move_flg = true;

                GameObject cursor = GameObject.Find("SelectCursor"); //オブジェクトを探す
                cursor.SetActive(false);

                //プレイヤーを停止
                auto_player_move.move_flg = false;

                //歯車のコライダー削除
                GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = false;
                }
                objects = GameObject.FindGameObjectsWithTag("RGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = false;
                }
            }
        }
    }
}
