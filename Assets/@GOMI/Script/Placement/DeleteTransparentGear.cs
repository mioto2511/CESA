using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTransparentGear : MonoBehaviour
{
    //GenerateGearの変数を使う
    GenerateGear2 generate_gear;
    //MoveCursor変数を使う
    MoveCursor move_cursor;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("SelectCursor"); //オブジェクトを探す
        move_cursor = obj.GetComponent<MoveCursor>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        //GenerateGearの変数を使う
        generate_gear = GetComponent<GenerateGear2>();

        if (Input.GetKeyDown("joystick button 0"))
        {
            //範囲の生成フラグがfalseなら消す
            if (generate_gear.generateflg == false)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag("Select");
                foreach (GameObject del in objects)
                {
                    Destroy(del);
                }

                Destroy(gameObject);

                //カーソルが動くようにする
                move_cursor.moveflg = true;
            }
        }
    }
}
