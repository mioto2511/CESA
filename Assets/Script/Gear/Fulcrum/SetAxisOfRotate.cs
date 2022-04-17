using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAxisOfRotate : MonoBehaviour
{
    //GearCollision�̕ϐ����g��
    //GearCollision gear_collision;
    //MoveAxisOfRotate�̕ϐ����g��
    MoveAxisOfRotate move_axis;
    //RotateRoom�̕ϐ����g��
    RotateRoom rotate_room;
    //RotateTest�̕ϐ����g��
    RightRotateTest rightrotate_test;
    //LeftRotateTest�̕ϐ����g��
    LeftRotateTest leftrotate_test;

    private int cunt = 0;

    private bool active = false;

    public bool collider_flg = true;

    //���̃R���C�_�[
    private Collider2D collider;

    public bool check = false;

    private bool right = false;
    private bool left = false;

    //�e�X�g�̏����ʒu�ۑ��p
    private Vector3 activebox_pos;

    private GameObject right_obj;
    private GameObject left_obj;

    //Vector3 box_pos;

    // Start is called before the first frame update
    void Start()
    {
        right_obj = transform.Find("RightTrigger").gameObject;
        rightrotate_test = right_obj.GetComponent<RightRotateTest>(); //�X�N���v�g���擾

        left_obj = transform.Find("LeftTrigger").gameObject;
        leftrotate_test = left_obj.GetComponent<LeftRotateTest>(); //�X�N���v�g���擾

        collider = this.GetComponent<Collider2D>();


        GameObject obj1 = GameObject.Find("AxisOfRotation"); //�I�u�W�F�N�g��T��
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj2 = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_room = obj2.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        //��4�ȏ�ɓ������Ă���
        if (cunt >= 4)
        {
            //Room��Box�ɓ������Ă���
            if (active)
            {
                //���g���擾
                Vector3 my_pos = this.transform.position;

                //���X�g�ɒǉ�
                //move_axis.axis_poses[0] = my_pos;
                //move_axis.axis_poses.Add(my_pos);

                //Debug.Log(this.name);
                active = false;

                //�x�_���ړ�������
                //move_axis.move_flg = true;

                //right = true;

                right_obj.transform.position = activebox_pos;
                left_obj.transform.position = activebox_pos;

                rightrotate_test.Move();
                leftrotate_test.Move();
            }


            //�x�_�Ɉړ�������
            //move_axis.axis_pos = my_pos;
        }

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
            collider.enabled = true;

            //rightrotate_test.ColliderSwith(1);
            //leftrotate_test.ColliderSwith(1);
        }
        else
        {
            collider.enabled = false;
            cunt = 0;
            //active = false;

            //rightrotate_test.ColliderSwith(0);
            //leftrotate_test.ColliderSwith(0);

            right_obj.transform.localPosition = new Vector3(0, 0, 0);
            left_obj.transform.localPosition = new Vector3(0, 0, 0);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            cunt++;
        }

        if (other.gameObject.CompareTag("ActiveBox"))
        {
            active = true;

            //���̓������Ă�box�̍��W
            activebox_pos = other.transform.position;
        }
    }
}
