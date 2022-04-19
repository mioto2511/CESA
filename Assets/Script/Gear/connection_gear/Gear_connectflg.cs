using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//接続歯車が回ったら部屋の接続フラグをオンにする
public class Gear_connectflg : MonoBehaviour
{
    //BoxVariableの変数を使う
    private BoxVariable box_variable;
    //RotateRoomの変数を使う
    private RotateRoom rotate_room;

    private bool flg = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Boxobj = transform.parent.gameObject;
        box_variable = Boxobj.GetComponent<BoxVariable>();

        GameObject obj = GameObject.Find("Room"); //オブジェクトを探す
        rotate_room = obj.GetComponent<RotateRoom>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "LGear_Connect")
        {
            box_variable.become_child = true;

            if (flg)
            {
                flg = false;
            }
        }
        else if(this.tag == "RGear_Connect")
        {
            box_variable.become_child = true;

            if (flg)
            {
                flg = false;
            }
        }
    }
}
