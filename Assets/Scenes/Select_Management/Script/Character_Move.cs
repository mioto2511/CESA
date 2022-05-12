using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    [Header("�ړ��o�H")] public GameObject[] movePoint;
    [Header("����")] public float speed = 1.0f;

    private Rigidbody2D rb = null;
    private int nowPoint = 0;
    private int point_scene = 0;
    private bool PointMax = false;
    private bool PointMin = false;
    private bool RightMove = false;
    private bool LeftMove = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (movePoint != null && movePoint.Length > 0 && rb != null)
        {
            //�L�����N�^�[���ړ��o�H�̂O�Ԗڂ̈ʒu��
            rb.position = movePoint[0].transform.position;
        }
    }

    // Select_Manager���瑗���Ă����V�[���ԍ����󂯎��
    public void Scene(int sceneNo)
    {
        point_scene = sceneNo;
    }

    private void Update()
    {
        //if(Input.GetAxis(""))
        // �Q�[���p�b�h�̓��͏���(���̓L�[�{�[�h�̖����͂ɂȂ��Ă���)
        if (Input.GetKeyDown(KeyCode.RightArrow) && RightMove == false && LeftMove == false && PointMax == false)
        {
            int nextPoint = nowPoint + 1;

            //�ړ��悪���J���̏ꍇ�s���Ȃ��悤�ɂ���
            if (movePoint[nextPoint].GetComponent<Select_Manager>().NewStageFlg == true)
            {
                RightMove = true;
                //SoundManager.Instance.PlaySE(SESoundData.SE.Select);
                //Debug.Log(nextPoint);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && RightMove == false && LeftMove == false && PointMin == false)
        {
            LeftMove = true;
            //SoundManager.Instance.PlaySE(SESoundData.SE.Select);
            //Debug.Log("L");
        }

        // �X�e�[�W�I������
        if (Input.GetKeyDown("joystick button 0") && RightMove == false && LeftMove == false)
        {
            //SoundManager.Instance.PlaySE(SESoundData.SE.Pick);
            Fade_Manager.FadeOut(point_scene); // A�{�^���������ꂽ��t�F�[�h�A�E�g���ăV�[���J�ڂ���
        }

        // �I�v�V�����{�^���������ꂽ�烏�[���h�Z���N�g�ɃV�[���J�ڂ���
        if(Input.GetKeyDown("joystick button 7"))
        {
            Fade_Manager.FadeOut(10);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ���쏈��
        if (movePoint != null && movePoint.Length > 1 && rb != null)
        {
            // �ʏ�i�s
            if (RightMove == true)
            {
                int nextPoint = nowPoint + 1;

                // �ڕW�̃|�C���g�܂ł̋������͂��ɂȂ�܂ňړ�
                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    // ���ݒn���玟�̃|�C���g�ւ̃x�N�g�����v�Z
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                    // ���̃|�C���g�ֈړ�
                    rb.MovePosition(toVector);
                }
                else
                { // ���̃|�C���g���P�i�߂� 
                    rb.MovePosition(movePoint[nextPoint].transform.position);
                    ++nowPoint;
                    // �ړI�n�ɒ������瓮����~�߂�
                    RightMove = false;
                }
            }
            else if (LeftMove == true)
            {
                int nextPoint = nowPoint - 1;

                // �ڕW�̃|�C���g�܂ł̋������͂��ɂȂ�܂ňړ�
                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    // ���ݒn���玟�̃|�C���g�ւ̃x�N�g�����v�Z
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                    // ���̃|�C���g�ֈړ�
                    rb.MovePosition(toVector);
                }
                else
                { // ���̃|�C���g���P�i�߂� 
                    rb.MovePosition(movePoint[nextPoint].transform.position);
                    --nowPoint;
                    // �ړI�n�ɒ������瓮����~�߂�
                    LeftMove = false;
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

    }
}
