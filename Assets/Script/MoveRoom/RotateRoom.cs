using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    //AutoPlayerMove�̕ϐ����g��
    private AutoPlayerMove auto_player_move;
    //MoveAxisOfRotate�̕ϐ����g��
    private MoveAxisOfRotate move_axis;
    //RotateStart�̕ϐ����g��
    private RotateStart rotate_start;
    //ChainGear���g��
    private ChainGear chain_gear;

    public static RotateRoom instance;
    public int rotate_cnt = 0;

    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    [Header("�^�[�Q�b�g�I�u�W�F�N�g")] public GameObject target_object;

    [Header("���x�W��")] public float SpeedFactor = 0.1f;

    //��]��
    private Vector3 RotateAxis = Vector3.forward;

    //�񂷂�
    public bool rotate_flg = false;

    //�����肩
    public bool right_rotate = false;
    public bool left_rotate = false;

    //�������m������������
    public bool room_hit = false;

    //�q��BOX�̃J�E���g
    private int child_cnt = 0;

    //���g��tf
    private Transform my_transform;

    //�f�b�g�]�[��
    private float deadzone = 0.2f;

    //�X�e�b�N�̊J�n�n�_
    private float start_radian = 0;

    //�X�e�b�N�̑O��p�x
    private float old_radian = 0;

    //�����ʒu�t���O
    private bool initial_flg = true;

    //�����ʒu
    private Vector3 initial_pos;

    //�I�u�W�F�N�g
    private GameObject player;
    //private GameObject cursor;

    //�x�_�̃R���C�_�[�t���O
    public bool collider_flg = true;

    void Start()
    {
        rotate_start = this.GetComponent<RotateStart>();//�t���Ă���X�N���v�g���擾

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //�I�u�W�F�N�g��T��
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();�@//�t���Ă���X�N���v�g���擾

        GameObject chain = GameObject.Find("DriveGear"); // �I�u�W�F�N�g��T��
        chain_gear = chain.GetComponent<ChainGear>();

        player = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        auto_player_move = player.GetComponent<AutoPlayerMove>();�@//�t���Ă���X�N���v�g���擾

        //cursor = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
    }

    void Update()
    {
        // transform���擾
        my_transform = this.transform;

        //��������������
        if (room_hit == true)
        {
            child_cnt++;

            rotate_flg = false;

            //box�̐��ƃJ�E���g���������ȏ�Ȃ�
            if (child_cnt >= this.transform.childCount)
            {
                room_hit = false;

                child_cnt = 0;

                //��]�����̏�����
                left_rotate = false;
                right_rotate = false;

                //�x�点�ď����������
                Invoke("DelayMethod", 0.25f);

                //�v���C���[���N��
                auto_player_move.move_flg = true;

                //�z��폜
                move_axis.Delete();

                //�J�[�\������           
                //cursor.SetActive(true);
                //�v���C���[�̈ʒu�ɃJ�[�\������
                //Vector3 player_pos = player.transform.position;
                //cursor.transform.position = player_pos;

                //��]�����ʒu�̏�����
                start_radian = 0;
                old_radian = 0;
                initial_flg = true;

                //���Ԃ̃R���C�_�[ON
                GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = true;
                }
                objects = GameObject.FindGameObjectsWithTag("RGear");
                foreach (GameObject num in objects)
                {
                    var colliderTest = num.GetComponent<Collider2D>();
                    colliderTest.enabled = true;
                }
            }
        }

        //�R���g���[���[�̏���
        StickMove();
    }

    void FixedUpdate()
    {
        // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
        if (rotate_flg == true)
        {
            if (right_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / -SpeedFactor) * Time.deltaTime
                );
            }
            else if (left_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / SpeedFactor) * Time.deltaTime
                );
            }
        }       
    }

    //�R���g���[���[�̏���
    private void StickMove()
    {
        if (rotate_flg == true)
        {
            float lsh = Input.GetAxis("L_Stick_H");//����
            float lsv = Input.GetAxis("L_Stick_V");//�c��

            //�X�e�b�N�̊p�x�Y�o
            float radian = Mathf.Atan2(lsv, lsh) * Mathf.Rad2Deg;
            if (radian < 0)
            {
                radian += 360;
            }

            //�X�e�B�b�N���͂��͂�������
            if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
            {
                //�����ʒu�̎�
                if (initial_flg)
                {
                    initial_flg = false;

                    //�X�e�B�b�N�̊J�n�p�x
                    start_radian = radian;

                    //��]�O�̏����ʒu
                    initial_pos = this.transform.position;
                }


                if (left_rotate == false && right_rotate == false)
                {
                    float now_radian = start_radian - radian;

                    //0�`360�Ŕ�Ԃ̂����P
                    if (old_radian >= 0 && now_radian < -200)
                    {
                        now_radian += 360;
                    }
                    else if (old_radian <= 0 && now_radian > 200)
                    {
                        now_radian -= 360;
                    }

                    //90�x��]�������]�J�n
                    if (now_radian >= 90 && chain_gear.dtype == 1)
                    {
                        right_rotate = true;

                        //������
                        move_axis.SetAxis(0);
                    }
                    else if (now_radian <= -90 && chain_gear.dtype == 0)
                    {
                        left_rotate = true;

                        //������
                        move_axis.SetAxis(1);
                    }

                    //�ۑ�
                    old_radian = now_radian;
                }
            }
            else if (lsh == 0 && lsv == 0)
            {
                //��]�����ʒu�̏�����
                start_radian = 0;
                old_radian = 0;
                initial_flg = true;
            }
        }
    }

    //�x������
    private void DelayMethod()
    {
        //�x�_�̃R���C�_�[ON
        collider_flg = true;

        //�{�^�����ӂ����щ�����
        rotate_start.botton_flg = true;
    }
}
