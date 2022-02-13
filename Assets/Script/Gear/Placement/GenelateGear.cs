using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenelateGear : MonoBehaviour
{
    //生成するオブジェクト
    public GameObject gear;

    //生成フラグ
    public bool GenerateFlg = true;

    //CursorCollisionの変数を使う
    CursorCollision cursor_collision;

    //GearDataの変数を使う
    GearData gear_data;

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        //vector3に変換
        Vector3 pos = myTransform.position;

        //変数を使える用にする
        cursor_collision = GetComponent<CursorCollision>();

        //変数を使える用にする
        GameObject obj = GameObject.Find("GearData"); 
        gear_data = obj.GetComponent<GearData>();

        if (Input.GetKeyDown("joystick button 0"))
        {
            //ほかの歯車に当たってないなら
            if(cursor_collision.cursorhit == false)
            {
                if (GenerateFlg == true)
                {
                    GameObject newgear = Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                    gear_data.GearList.Add(newgear);// リストにプレファブを加える

                    for (int i = 0; i < gear_data.GearList.Count; i++)
                    {
                        Debug.Log(gear_data.GearList[i]);
                    }
                }
            }
        }
    }
}
