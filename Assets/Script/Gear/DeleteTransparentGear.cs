using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTransparentGear : MonoBehaviour
{
    //GenerateTransparentGearの変数を使う
    GenerateTransparentGear generate_transparent_gear;

    //CursorCollisionの変数を使う
    CursorCollision cursor_collision;

    // Update is called once per frame
    void Update()
    {
        //変数を使える用にする
        cursor_collision = GetComponent<CursorCollision>();

        //GenerateTransparentGearがついているオブジェクト
        GameObject gear = GameObject.Find("Gear");

        generate_transparent_gear = gear.GetComponent<GenerateTransparentGear>();

        if (Input.GetKeyDown("joystick button 0"))
        {
            //歯車に触れていなかったら
            if(cursor_collision.cursorhit == false)
            {
                //範囲の生成フラグがfalseなら消す
                if (generate_transparent_gear.generateflg == false)
                {
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("Select");
                    foreach (GameObject del in objects)
                    {
                        Destroy(del);
                    }

                    Destroy(gameObject);
                }
            }
        }
    }
}
