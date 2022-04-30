using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuesorManager : MonoBehaviour
{
    [Header("���[���h�}�b�v")] public GameObject[] movePoint;

    private int nowPoint = 0;
    private bool PointMax = false;
    private bool PointMin = false;

    private Shutter shutterL;
    private Shutter shutterR;
    private ChangeScene change_scene;

    // Start is called before the first frame update
    void Start()
    {
        GameObject L = GameObject.Find("ShutterL"); // �I�u�W�F�N�g��T��
        shutterL = L.GetComponent<Shutter>();

        GameObject R = GameObject.Find("ShutterR"); // �I�u�W�F�N�g��T��
        shutterR = R.GetComponent<Shutter>();

        GameObject T = GameObject.Find("ShutterTrigger"); // �I�u�W�F�N�g��T��
        change_scene = T.GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���[���h�I������
        if (Input.GetKeyDown("joystick button 0"))
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Pick);

            shutterL.shutter_flg = true;
            shutterR.shutter_flg = true;

            change_scene.NextScene(movePoint[nowPoint].GetComponent<WorldManager>().World_No);

            //Fade_Manager.FadeOut(movePoint[nowPoint].GetComponent<WorldManager>().World_No); // A�{�^���������ꂽ��t�F�[�h�A�E�g���ăV�[���J�ڂ���
            //Debug.Log(movePoint[nowPoint].GetComponent<World_Manager>().World_No);
        }

        // �Q�[���p�b�h�̓��͏���(���̓L�[�{�[�h�̖����͂ɂȂ��Ă���)
        if (Input.GetKeyDown(KeyCode.RightArrow)�@&& PointMax == false)
        {
            int nextPoint = nowPoint + 1;

            //�ړ��悪���J���̏ꍇ�s���Ȃ��悤�ɂ���
            if (movePoint[nextPoint].GetComponent<WorldManager>().clear == true)
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Select);
                ++nowPoint;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && PointMin == false)
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Select);
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
