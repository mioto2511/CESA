using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

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
    //Acceleration�̕ϐ����g��
    private Acceleration acceleration;
    //VibrationScript
    private VibrationScript vibration_script;

    private GoalActive goal_active;

    private HitStop hit_stop;

    public int dtype;

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

    [Header("�f�b�g�]�[��")] public float deadzone = 0.8f;

    [Header("����")] public float add_speed = 0.0025f;

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

    //�x�_�̃R���C�_�[�t���O
    public bool collider_flg = true;

    // se
    private int secout;

    //������
    private float add = 0;

    public bool start_flg = true;

    // player�̃p�[�e�B�N��
    private Material player_prt;

    void Start()
    {
        rotate_start = this.GetComponent<RotateStart>();//�t���Ă���X�N���v�g���擾
        vibration_script = this.GetComponent<VibrationScript>();

        GameObject obj2 = GameObject.Find("Main Camera");
        hit_stop = obj2.GetComponent <HitStop>();

        GameObject obj3 = GameObject.Find("Goal/DriveGear");
        goal_active = obj3.GetComponent<GoalActive>();

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //�I�u�W�F�N�g��T��
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();�@//�t���Ă���X�N���v�g���擾

        GameObject chain = GameObject.Find("DriveGear"); // �I�u�W�F�N�g��T��
        chain_gear = chain.GetComponent<ChainGear>();

        player = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        auto_player_move = player.GetComponent<AutoPlayerMove>();�@//�t���Ă���X�N���v�g���擾
        acceleration = player.GetComponent<Acceleration>();//�t���Ă���X�N���v�g���擾

        // player�ɂ��Ă���p�[�e�B�N��
         // ��������Abutton���������Ƃ��̃p�[�e�B�N���̃}�e���A��
        GameObject prt = GameObject.Find("ParticleActive");
        player_prt = prt.GetComponent<Renderer>().material;

        dtype = 2;

        secout=0;
    }

    void Update()
    {
        // transform���擾
        my_transform = this.transform;

        //��������������
        if (room_hit == true)
        {
            if (start_flg)
            {
                start_flg = false;
                room_hit = false;
            }
            else
            {
                child_cnt++;

                rotate_flg = false;

                //box�̐��ƃJ�E���g���������ȏ�Ȃ�
                if (child_cnt >= this.transform.childCount)
                {
                    room_hit = false;

                    child_cnt = 0;

                    add = 0;

                    //��]�����̏�����
                    left_rotate = false;
                    right_rotate = false;

                    //�x�点�ď����������
                    Invoke("DelayMethod", 1.5f);

                    hit_stop.hitstop_flg = true;

                    //�v���C���[���N��
                    auto_player_move.move_flg = true;

                    //�z��폜
                    move_axis.Delete();

                    //�����\�ɂ���
                    acceleration.button_flg = true;

                    //�U��
                    vibration_script.Vibration(0.8f, 0.8f,0.1f);

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

            
        }

        //�R���g���[���[�̏���
        StickMove();
    }

    void FixedUpdate()
    {
        //float a= 2;

        //Debug.Log(old_radian);
        // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
        if (rotate_flg == true)
        {
            if (right_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / -(SpeedFactor + add)) * Time.deltaTime
                );

                //this.transform.RotateAround(
                //target_object.transform.position,
                //RotateAxis,
                //360.0f / (1.0f / -SpeedFactor) * Time.deltaTime
                //);
            }
            else if (left_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / (SpeedFactor + add)) * Time.deltaTime
                );
                //this.transform.RotateAround(
                //target_object.transform.position,
                //RotateAxis,
                //360.0f / (1.0f / SpeedFactor) * Time.deltaTime
                //);
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

            float now_radian = 0;

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
                else
                {
                    now_radian = start_radian - radian;


                    //0�`360�Ŕ�Ԃ̂����P
                    if (old_radian >= 0 && now_radian < -200)
                    {
                        now_radian += 360;
                    }
                    else if (old_radian <= 0 && now_radian > 200)
                    {
                        now_radian -= 360;
                    }

                    if (now_radian >= 90)
                    {
                        add += add_speed;
                    }
                    if (now_radian <= -90)
                    {
                        add += add_speed;
                    }

                    //Debug.Log(SpeedFactor + add);
                }

                if (left_rotate == false && right_rotate == false)
                {
                    //90�x��]�������]�J�n
                    if (dtype == 2)
                    {
                        if (now_radian >= 90)
                        {
                            right_rotate = true;

                            //������
                            move_axis.SetAxis(0);

                            // Particle������
                            player_prt.SetFloat("_alpha", 0);
                        }
                        else if (now_radian <= -90)
                        {
                            left_rotate = true;

                            //������
                            move_axis.SetAxis(1);

                            // Particle������
                            player_prt.SetFloat("_alpha", 0);
                        }
                    }
                    else if(dtype <= 1)
                    {
                        if (dtype == 1)
                        {
                            if (now_radian >= -80 && now_radian <= -1)
                            {
                                now_radian = 0;
                            }
                            if (now_radian >= 90)
                            {
                                right_rotate = true;

                                //������
                                move_axis.SetAxis(0);
                            }
                        }
                        if (dtype == 0)
                        {
                            if (now_radian <= 80 && now_radian >= 1)
                            {
                                now_radian = 0;
                            }
                            else if (now_radian <= -90)
                            {
                                left_rotate = true;

                                //������
                                move_axis.SetAxis(1);
                            }
                        }
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

        if (!goal_active.goal_active)
        {
            //�{�^�����ӂ����щ�����
            rotate_start.botton_flg = true;
        }
        
    }

    private void StickMove2()
    {
        if (rotate_flg)
        {
            float lsh = Input.GetAxis("L_Stick_H");//����
            float lsv = Input.GetAxis("L_Stick_V");//�c��

            //�X�e�b�N�̊p�x�Y�o
            float radian = Mathf.Atan2(lsv, lsh) * Mathf.Rad2Deg;
            if (radian < 0)
            {
                radian += 360;
            }

            //if (start_radian > 10 && radian > 300)
            //{
            //    radian = -radian;
            //    radian = radian + 360;
            //}

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

                if (start_radian >= radian)
                {
                    //������
                    move_axis.SetAxis(0);
                    right_rotate = true;
                    old_radian = start_radian - radian;
                    start_radian = radian;
                }
                else if (start_radian <= radian)
                {
                    //������
                    move_axis.SetAxis(1);
                    left_rotate = true;

                    old_radian = start_radian - radian;
                    start_radian = radian;
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

    //private void RotateSE()
    //{
    //    if ((left_rotate == true || right_rotate == true) && secout == 0) 
    //    {
    //        SEManager.Instance.Play(SEPath.SE_001);
    //        //Debug.Log(secout);
    //        secout = 1;
    //        Debug.Log(secout);
    //    }
    //    else if(left_rotate == false || right_rotate == false)
    //    {
    //        //SEManager.Instance.Stop(SEPath.SE_001);
    //        Debug.Log("Stop");
    //        secout = 0;
    //    }
    //}
}
