using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGear : MonoBehaviour
{
    //GearDataの変数を使う
    GearData gear_data;

    // Start is called before the first frame update
    void Start()
    {
        // transformを取得
        Transform myTransform = this.transform;

        //変数を使える用にする
        GameObject obj = GameObject.Find("GearData");
        gear_data = obj.GetComponent<GearData>();

        // transformを取得
        Transform Transform = gear_data.GearList[0].transform;

        //selectcursorを初期値へ
        myTransform.position = Transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        //vector3に変換
        Vector3 mypos = myTransform.position;
    }
}
