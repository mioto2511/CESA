using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
using UnityEngine.SceneManagement;

public class CuesorManager : MonoBehaviour
{
    [Header("���[���h�}�b�v")] public GameObject[] movePoint;

    [Header("�g��")] public float up_size = 0.19f;

    private GameObject kari;

    private int nowPoint = 0;
    private int oldPoint = 0;
    private bool PointMax = false;
    private bool PointMin = false;

    private OpenShutter shutter;
    private ChangeScene change_scene;

    //�f�b�g�]�[��
    private float deadzone = 0.2f;

    private bool stick_flg = true;

    private bool button_flg = true;

    public LoopFrame loop_frame;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // �I�u�W�F�N�g��T��
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<OpenShutter>();

        kari = GameObject.Find("Fuchi");
        kari.transform.localScale = new Vector3(up_size, up_size, 1);
        movePoint[nowPoint].transform.localScale = new Vector3(up_size, up_size, 1);

        Vector3 pos = movePoint[nowPoint].transform.position;
        kari.transform.position = new Vector3(pos.x, pos.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (button_flg)
        {
            // ���[���h�I������
            if (Input.GetKeyDown("joystick button 0"))
            {
               // SEManager.Instance.Play(SEPath.SE_005);

                button_flg = false;

                shutter.shutter_flg = true;

                //���惋�[�v��~
                loop_frame.loop_flg = false;

                change_scene.NextScene(movePoint[nowPoint].GetComponent<WorldManager>().World_No);

                //�X�e�[�W�ԍ��̕ۑ�
                PlayerPrefs.SetInt("OLDSTAGE", 1);
                PlayerPrefs.Save();
                //SceneManager.LoadScene(movePoint[nowPoint].GetComponent<WorldManager>().World_No);

                //Fade_Manager.FadeOut(movePoint[nowPoint].GetComponent<WorldManager>().World_No); // A�{�^���������ꂽ��t�F�[�h�A�E�g���ăV�[���J�ڂ���
                //Debug.Log(movePoint[nowPoint].GetComponent<World_Manager>().World_No);          
            }
        }
        

        float lsh = Input.GetAxis("L_Stick_H");//����
        //Debug.Log(nowPoint);
        if (stick_flg)
        {
            // �Q�[���p�b�h�̓��͏���(���̓L�[�{�[�h�̖����͂ɂȂ��Ă���)
            if (lsh > deadzone && PointMax == false)
            {
                stick_flg = false;

                int nextPoint = nowPoint + 1;

                //�ړ��悪�J���̏ꍇ�s����悤�ɂ���
                if (movePoint[nextPoint].GetComponent<WorldManager>().clear == true)
                {
                    //SEManager.Instance.Play(SEPath.SE_004);
                    ++nowPoint;

                    //�J�[�\���ݒu
                    Vector3 pos = movePoint[nowPoint].transform.position;
                    kari.transform.position = new Vector3(pos.x, pos.y, 0);

                    movePoint[nowPoint].transform.localScale = new Vector3(up_size, up_size, 1);
                    movePoint[oldPoint].transform.localScale = new Vector3(0.18f, 0.18f, 1);

                    oldPoint = nowPoint;
                }
                //�x�点�ď����������
                Invoke("DelayMethod", 0.5f);
            }
            if (lsh < -deadzone && PointMin == false)
            {
                stick_flg = false;

                //SoundManager.Instance.PlaySE(SESoundData.SE.Select);
                --nowPoint;

                //�J�[�\���ݒu
                Vector3 pos = movePoint[nowPoint].transform.position;
                kari.transform.position = new Vector3(pos.x, pos.y, 0);

                movePoint[nowPoint].transform.localScale = new Vector3(up_size, up_size, 1);
                movePoint[oldPoint].transform.localScale = new Vector3(0.18f,0.18f,1);

                oldPoint = nowPoint;

                //�x�点�ď����������
                Invoke("DelayMethod", 0.5f);
            }
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

    //�x������
    private void DelayMethod()
    {
        stick_flg = true;
    }
}
