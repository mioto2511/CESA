using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPowrGear : MonoBehaviour
{
    //スクリプト用変数
    GimmickData gimmick_data;

    // Start is called before the first frame update
    void Start()
    {
        //ここで親を取得
        GameObject gimmick = this.transform.parent.gameObject;
        //親オブジェクトのスクリプトから参照したい変数を代入
        gimmick_data = gimmick.GetComponent<GimmickData>();
    }

    // Update is called once per frame
    void Update()
    {
        //回転の向き確認
        Vector3 rotate = transform.localEulerAngles;

        if (Input.GetKey("joystick button 0"))
        {
            gimmick_data.left_rotate = true;
            gimmick_data.right_rotate = false;
            gimmick_data.IsOn = true;
        }
        else if (Input.GetKey("joystick button 1"))
        {
            gimmick_data.right_rotate = true;
            gimmick_data.left_rotate = false;
            gimmick_data.IsOn = true;
        }

        //左回転
        if (gimmick_data.left_rotate == true)
        {
            transform.Rotate(new Vector3(0, 0, 2));
        }
        else if (gimmick_data.right_rotate == true)
        {
            transform.Rotate(new Vector3(0, 0, -2));
        }
    }
}
