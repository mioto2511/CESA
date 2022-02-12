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
        //10�T�C�Y����g��
        if (Input.GetKey(KeyCode.RightArrow) && scale == 1.0f)
        {
            if (pushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
            {
                pushFlag = true;    // ������Ԃɂ���
                scale += 0.5f;
                transform.localScale = new Vector3(scale, scale, 1.0f);
            }
        }
        else
        {
            pushFlag = false;
        }

        //15�T�C�Y����g��
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (pushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
            {
                if (scale == 1.5f)
                {
                    scale += 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
                pushFlag = true;    // ������Ԃɂ���
            }
        }
        else
        {
            pushFlag = false;
        }

        //15�T�C�Y����k��
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (pushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
            {
                if (scale == 1.5f)
                {
                    pushFlag = true;    // ������Ԃɂ���
                    scale -= 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
            }
        }
        else
        {
            pushFlag = false;
        }

        //20�T�C�Y����k��
        if (Input.GetKey(KeyCode.LeftArrow) && scale == 2.0f)
        {
            if (pushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
            {
                pushFlag = true;    // ������Ԃɂ���
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
