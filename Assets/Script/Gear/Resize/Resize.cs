using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    private float scale;
    bool pushFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        scale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //拡大
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (pushFlag == false)  // 押しっぱなしではないとき
            {
                pushFlag = true;    // 押し状態にする

                if (scale == 1.0f)   //10サイズから
                {
                    scale += 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
                else if (scale == 1.5f)   //15サイズから
                {
                    scale += 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
            }
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            pushFlag = false;
        }

        //縮小
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pushFlag == false)  // 押しっぱなしではないとき
            {
                if (scale == 1.5f)//15サイズから
                {
                    pushFlag = true;    // 押し状態にする
                    scale -= 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
                else if (scale == 2.0f)  //20サイズから
                {
                    pushFlag = true;    // 押し状態にする
                    scale -= 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            pushFlag = false;
        }
    }
}
