using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStart : MonoBehaviour
{
    //AutoPlayerMove�̕ϐ����g��
    private AutoPlayerMove auto_player_move;
    //MoveAxisOfRotate�̕ϐ����g��
    private MoveAxisOfRotate move_axis;
    //Acceleration�̕ϐ����g��
    private Acceleration acceleration;

    //�{�^���t���O
    public bool botton_flg = true;

    private float deadzone = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj1 = GameObject.Find("AxisOfRotation"); //�I�u�W�F�N�g��T��
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj2 = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();�@//�t���Ă���X�N���v�g���擾
        acceleration = obj2.GetComponent<Acceleration>();//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (botton_flg)
        {
            //StickEnter();
            if (Input.GetKeyDown("joystick button 0"))
            {
                //���Ԃ𓙔{��
                Time.timeScale = 1;

                //�{�^���������Ȃ�����
                botton_flg = false;

                //���Z�b�g
                move_axis.move_flg = true;

                //�v���C���[���~
                auto_player_move.move_flg = false;

                //�����s�\�ɂ���
                acceleration.button_flg = false;

                //���Ԃ̃R���C�_�[�폜
                GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = false;
                }
                objects = GameObject.FindGameObjectsWithTag("RGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = false;
                }

            }
        }
        
    }

    void StickEnter()
    {
        float lsh = Input.GetAxis("L_Stick_H");//����
        float lsv = Input.GetAxis("L_Stick_V");//�c��

        //�X�e�B�b�N���͂��͂�������
        if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
        {
            //���Ԃ𓙔{��
            Time.timeScale = 1;

            //�{�^���������Ȃ�����
            botton_flg = false;

            //���Z�b�g
            move_axis.move_flg = true;

            //�v���C���[���~
            auto_player_move.move_flg = false;

            //�����s�\�ɂ���
            acceleration.button_flg = false;

            //���Ԃ̃R���C�_�[�폜
            GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
            foreach (GameObject num in objects)
            {
                var colliderTest = num.GetComponent<Collider2D>();
                colliderTest.enabled = false;
            }
            objects = GameObject.FindGameObjectsWithTag("RGear");
            foreach (GameObject num in objects)
            {
                var colliderTest = num.GetComponent<Collider2D>();
                colliderTest.enabled = false;
            }
        }
        //else
        //{
        //    //�{�^���������Ȃ�����
        //    botton_flg = true;

        //    //���Z�b�g
        //    move_axis.move_flg = false;

        //    //�v���C���[���~
        //    auto_player_move.move_flg = true;

        //    //�����s�\�ɂ���
        //    acceleration.button_flg = true;

        //    //���Ԃ̃R���C�_�[�폜
        //    GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
        //    foreach (GameObject num in objects)
        //    {
        //        var colliderTest = num.GetComponent<Collider2D>();
        //        colliderTest.enabled = true;
        //    }
        //    objects = GameObject.FindGameObjectsWithTag("RGear");
        //    foreach (GameObject num in objects)
        //    {
        //        var colliderTest = num.GetComponent<Collider2D>();
        //        colliderTest.enabled = true;
        //    }
        //}

    }
}
