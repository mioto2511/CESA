using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTransparentGear : MonoBehaviour
{
    //GenerateTransparentGearの変数を使う
    GenerateTransparentGear generate_transparent_gear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GenerateTransparentGearがついているオブジェクト
        GameObject gear = GameObject.Find("Gear");

        generate_transparent_gear = gear.GetComponent<GenerateTransparentGear>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //範囲の生成フラグがfalseなら消す
            if(generate_transparent_gear.generateflg == false)
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
