using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    public static RotateRoom instance;
    public int rotate_cnt = 0;

    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    [SerializeField, Tooltip("�^�[�Q�b�g�I�u�W�F�N�g")]
    private GameObject target_object;

    [SerializeField, Tooltip("��]��")]
    private Vector3 RotateAxis = Vector3.forward;

    [SerializeField, Tooltip("���x�W��")]
    private float SpeedFactor = 0.1f;

    //�񂷂�
    public bool rotate_flg = false;

    //�����肩
    public bool right_rotate = false;
    public bool left_rotate = false;

    //�������m������������
    public bool room_hit = false;

    private int child_cnt = 0;

    //���g��tf
    Transform my_transform;
    Vector3 my_rotate;

    //AutoPlayerMove�̕ϐ����g��
    AutoPlayerMove auto_player_move;

    void Start()
    {
        GameObject obj2 = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();�@//�t���Ă���X�N���v�g���擾
    }

    void Update()
    {
        // transform���擾
        my_transform = this.transform;

        ////��]�����̕ύX
        //if (Input.GetKeyDown("joystick button 5"))//�E
        //{
        //    right_rotate = true;
        //    left_rotate = false;
        //    Debug.Log("R");
        //}
        //else if (Input.GetKeyDown("joystick button 4"))//��
        //{
        //    left_rotate = true;
        //    right_rotate = false;
        //    Debug.Log("L");
        //}

        //��������������
        if (room_hit == true)
        {
            child_cnt++;

            if (child_cnt >= this.transform.childCount)
            {
                room_hit = false;
                child_cnt = 0;

                //��]�����̏�����
                left_rotate = false;
                right_rotate = false;

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

                //�J�[�\���̃^�O�ύX
                GameObject obj = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
                obj.tag = "Cursor";

                //�v���C���[���N��
                auto_player_move.move_flg = true;
            }
            
        }

        // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
        if (rotate_flg == true)
        {
            if(right_rotate == true)
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
}
