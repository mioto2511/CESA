using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTransparentGear : MonoBehaviour
{
    //GenerateTransparentGearの変数を使う
    GenerateTransparentGear generate_transparent_gear;

    // Update is called once per frame
    void Update()
    {
        //GenerateTransparentGearがついているオブジェクト
        GameObject gear = GameObject.Find("Gear");

        generate_transparent_gear = gear.GetComponent<GenerateTransparentGear>();

        if (Input.GetKeyDown("joystick button 0"))
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
