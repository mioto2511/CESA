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

    private int cunt = 0;

    private bool active = false;

    public bool collider_flg = true;


    Collider2D collider;

    //Vector3 box_pos;

    // Start is called before the first frame update
    void Start()
    {
        //gear_collision = GetComponent<GearCollision>(); //�X�N���v�g���擾

        collider = this.GetComponent<Collider2D>();


        GameObject obj1 = GameObject.Find("AxisOfRotation"); //�I�u�W�F�N�g��T��
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj2 = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_room = obj2.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        //if(gear_collision.gear_hit == true)
        //{
            
        //}
        //��4�ɓ������Ă���
        if (cunt == 4)
        {
            //Room��Box�ɓ������Ă���
            if (active)
            {
                //���g���擾
                Vector3 my_pos = this.transform.position;

                //���X�g�ɒǉ�
                move_axis.axis_poses.Add(my_pos);

                //�E��
                //if(my_pos.x > box_pos.x && my_pos.y < box_pos.y)
                //{
                //    //Ray�̍쐬
                //    Ray ray = new Ray(transform.position, new Vector3(-1, 0,0));

                //    //Ray�����������I�u�W�F�N�g�̏������锠
                //    RaycastHit2D hit;

                //    //Ray�̔�΂��鋗��
                //    int distance = 6;
                //    if (Physics2D.Raycast((Vector2)ray, out hit, distance))
                //    {
                //        //Ray�����������I�u�W�F�N�g��tag��Player��������
                //        if (hit.collider.tag == "FulcrumGear")
                //            Debug.Log("Ray��Player�ɓ�������");
                //    }
                //    right_flg = true;
                //}
                //else if (my_pos.x < box_pos.x && my_pos.y < box_pos.y)
                //{
                //    left_flg = true;
                //}
                //if (my_pos.x > box_pos.x && my_pos.y < box_pos.y)
                //{
                //    right_flg = true;
                //}
                //if (my_pos.x > box_pos.x && my_pos.y < box_pos.y)
                //{
                //    right_flg = true;
                //}

                Debug.Log(this.name);
                active = false;

                //�x�_���ړ�������
                //move_axis.move_flg = true;
            }


            //�x�_�Ɉړ�������
            //move_axis.axis_pos = my_pos;

            //gear_collision.gear_hit = false;
        }

        //�R���C�_�[��ON/OFF
        if (rotate_room.collider_flg)
        {
            collider.enabled = true;
            
        }
        else
        {
            collider.enabled = false;
            cunt = 0;
            active = false;

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

            //box_pos = other.transform.position; 
        }
    }
}
