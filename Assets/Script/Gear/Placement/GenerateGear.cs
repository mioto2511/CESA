using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGear : MonoBehaviour
{
    //生成するオブジェクト
    public GameObject wood_gear;
    public GameObject iron_gear;

    //材質用
    enum MATERIAL
    { 
        WOOD,
        IRON,
    };

    private int now_material = (int)MATERIAL.IRON;

    //生成フラグ
    public bool generateflg = true;

    //SelectCollisionの変数を使う
    SelectCollision select_collision;

    //GearDataの変数を使う
    GearData gear_data;

    void Start()
    {
        //変数を使える用にする
        GameObject obj = GameObject.Find("GearData");
        gear_data = obj.GetComponent<GearData>();
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        //vector3に変換
        Vector3 pos = myTransform.position;

        //変数を使える用にする
        select_collision = GetComponent<SelectCollision>();

        //材質選択
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            now_material = (int)MATERIAL.WOOD;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            now_material = (int)MATERIAL.IRON;
        }


        if (Input.GetKeyDown("joystick button 0"))
        {
            //ほかの歯車に当たってないなら
            if(select_collision.cursorhit == false)
            {
                if (generateflg == true)
                {
                    if(now_material == (int)MATERIAL.WOOD)
                    {
                        GameObject newgear = Instantiate(wood_gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                        gear_data.GearList.Add(newgear);// リストにプレファブを加える
                    }
                    else if (now_material == (int)MATERIAL.IRON)
                    {
                        GameObject newgear = Instantiate(iron_gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                        gear_data.GearList.Add(newgear);// リストにプレファブを加える
                    }

                    //デバック用
                    for (int i = 0; i < gear_data.GearList.Count; i++)
                    {
                        //Debug.Log(gear_data.GearList[i]);
                    }

                    //歯車生成フラグを折る
                    generateflg = false;
                }
            }
        }
    }
}
