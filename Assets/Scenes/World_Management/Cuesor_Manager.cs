using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuesor_Manager : MonoBehaviour
{
    [Header("���[���h�}�b�v")] public GameObject[] movePoint;

    private int nowPoint = 0;
    private bool PointMax = false;
    private bool PointMin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���[���h�I������
        if (Input.GetKeyDown("joystick button 0"))
        {
            Fade_Manager.FadeOut(movePoint[nowPoint].GetComponent<World_Manager>().World_No); // A�{�^���������ꂽ��t�F�[�h�A�E�g���ăV�[���J�ڂ���
            //Debug.Log(movePoint[nowPoint].GetComponent<World_Manager>().World_No);
        }

        // �Q�[���p�b�h�̓��͏���(���̓L�[�{�[�h�̖����͂ɂȂ��Ă���)
        if (Input.GetKeyDown(KeyCode.RightArrow)�@&& PointMax == false)
        {
            int nextPoint = nowPoint + 1;

            //�ړ��悪���J���̏ꍇ�s���Ȃ��悤�ɂ���
            if (movePoint[nextPoint].GetComponent<World_Manager>().clear == true)
            {
                ++nowPoint;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && PointMin == false)
        {
            --nowPoint;
            //Debug.Log("L");
        }

        // ���ݒn���z��̍Ōゾ�����ꍇ
        if (nowPoint + 1 >= movePoint.Length)
        {
            PointMax = true;
            //Debug.Log("max");
        }
        else
        {
            PointMax = false;
        }
        // ���ݒn���z��̍ŏ��������ꍇ
        if (nowPoint <= 0)
        {
            PointMin = true;
            //Debug.Log("min");
        }
        else
        {
            PointMin = false;
        }
    }
}
