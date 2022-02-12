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
        //10サイズから拡大
        if (Input.GetKey(KeyCode.RightArrow) && scale == 1.0f)
        {
            if (pushFlag == false)  // 押しっぱなしではないとき
            {
                pushFlag = true;    // 押し状態にする
                scale += 0.5f;
                transform.localScale = new Vector3(scale, scale, 1.0f);
            }
        }
        else
        {
            pushFlag = false;
        }

        //15サイズから拡大
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (pushFlag == false)  // 押しっぱなしではないとき
            {
                if (scale == 1.5f)
                {
                    scale += 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
                pushFlag = true;    // 押し状態にする
            }
        }
        else
        {
            pushFlag = false;
        }

        //15サイズから縮小
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (pushFlag == false)  // 押しっぱなしではないとき
            {
                if (scale == 1.5f)
                {
                    pushFlag = true;    // 押し状態にする
                    scale -= 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
            }
        }
        else
        {
            pushFlag = false;
        }

        //20サイズから縮小
        if (Input.GetKey(KeyCode.LeftArrow) && scale == 2.0f)
        {
            if (pushFlag == false)  // 押しっぱなしではないとき
            {
                pushFlag = true;    // 押し状態にする
                scale -= 0.5f;
                transform.localScale = new Vector3(scale, scale, 1.0f);
            }
        }
        else
        {
            pushFlag = false;
        }

    }
}
