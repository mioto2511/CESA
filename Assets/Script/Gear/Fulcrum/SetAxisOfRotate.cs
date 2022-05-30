using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAxisOfRotate : MonoBehaviour
{
    //MoveAxisOfRotate�̕ϐ����g��
    MoveAxisOfRotate move_axis;
    //RotateRoom�̕ϐ����g��
    RotateRoom rotate_room;
    //RotateTest�̕ϐ����g��
    RightRotateTest rightrotate_test;
    //LeftRotateTest�̕ϐ����g��
    LeftRotateTest leftrotate_test;

    private int count = 0;

    private bool active = false;

    public bool collider_flg = true;

    //���̃R���C�_�[
    private Collider2D my_collider;

    //�e�X�g�̏����ʒu�ۑ��p
    private Vector3 activebox_pos;

    private GameObject right_obj;
    private GameObject left_obj;

    private bool hit_flg = true;
    //private int startcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //���g�̃R���C�_�[
        my_collider = this.GetComponent<Collider2D>();

        right_obj = transform.Find("RightTrigger").gameObject;//�I�u�W�F�N�g��T��
        rightrotate_test = right_obj.GetComponent<RightRotateTest>(); //�X�N���v�g���擾

        left_obj = transform.Find("LeftTrigger").gameObject;//�I�u�W�F�N�g��T��
        leftrotate_test = left_obj.GetComponent<LeftRotateTest>(); //�X�N���v�g���擾

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //�I�u�W�F�N�g��T��
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj2 = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_room = obj2.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        //��4�ȏ�ɓ������Ă���
        if (count >= 4)
        {
            //Room��Box�ɓ������Ă���
            if (active)
            {
                //���g���擾
                Vector3 my_pos = this.transform.position;

                active = false;

                hit_flg = false;

                //�x�_�ɐG��Ă���Box�̈ʒu�Ƀe�X�g�I�u�W�F�N�g�z�u
                right_obj.transform.position = activebox_pos;
                left_obj.transform.position = activebox_pos;

                //��]�e�X�g
                rightrotate_test.Move();
                leftrotate_test.Move();
            }
        }

        //�e�X�g�I�u�W�F�N�g��Box�ɐG��ĂȂ��Ȃ�z��ɑ��
        if (rightrotate_test.box_hit == false)
        {
            if(right_obj.transform.position != this.transform.position)
            {
                Vector3 my_pos = this.transform.position;
                move_axis.axis_poses[0] = my_pos;
            }          
        }
        if (leftrotate_test.box_hit == false)
        {
            if (right_obj.transform.position != this.transform.position)
            {
                Vector3 my_pos = this.transform.position;
                move_axis.axis_poses[1] = my_pos;
            }                
        }

        //�R���C�_�[��ON/OFF
        if (rotate_room.collider_flg)
        {
            hit_flg = true;
            //�R���C�_�[ON
            my_collider.enabled = true;
        }
        else
        {
            //�R���C�_�[OFF
            my_collider.enabled = false;

            //�J�E���g������
            count = 0;

            //�e�X�g�I�u�W�F�N�g�ʒu������
            right_obj.transform.localPosition = new Vector3(0, 0, 0);
            left_obj.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            count++;
        }

        //if (other.gameObject.CompareTag("ActiveBox"))
        //{
        //    Debug.Log(gameObject.name);
        //    active = true;

        //    //���̓������Ă�box�̍��W
        //    activebox_pos = other.transform.position;
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hit_flg)
        {
            if (collision.gameObject.CompareTag("ActiveBox"))
            {
                //Debug.Log(gameObject.name);
                active = true;

                //���̓������Ă�box�̍��W
                activebox_pos = collision.transform.position;
            }
        }
    }
}
