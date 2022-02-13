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
        //�g��
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (pushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
            {
                pushFlag = true;    // ������Ԃɂ���

                if (scale == 1.0f)   //10�T�C�Y����
                {
                    scale += 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
                else if (scale == 1.5f)   //15�T�C�Y����
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

        //�k��
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pushFlag == false)  // �������ςȂ��ł͂Ȃ��Ƃ�
            {
                if (scale == 1.5f)//15�T�C�Y����
                {
                    pushFlag = true;    // ������Ԃɂ���
                    scale -= 0.5f;
                    transform.localScale = new Vector3(scale, scale, 1.0f);
                }
                else if (scale == 2.0f)  //20�T�C�Y����
                {
                    pushFlag = true;    // ������Ԃɂ���
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
