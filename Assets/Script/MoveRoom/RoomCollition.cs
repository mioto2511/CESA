using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class RoomCollition : MonoBehaviour
{
    //RotateRoom�ϐ����g��
    private RotateRoom root_room;
    //BoxVariable
    private BoxVariable box_variable;

    //���g��tf
    private Transform my_transform;

    //�e�Ɛe�̐e
    private GameObject parent;
    private GameObject root;

    Vector3 save_pos;

    Transform tf;


    private void Awake()
    {
        save_pos = this.transform.localPosition;

        Debug.Log(save_pos);
    }

    // Start is called before the first frame update
    void Start()
    {
        root = this.transform.parent.parent.gameObject; //�I�u�W�F�N�g��T��
        root_room = root.GetComponent<RotateRoom>(); //�t���Ă���X�N���v�g���擾

        parent = this.transform.parent.gameObject; //�I�u�W�F�N�g��T��
        box_variable = parent.GetComponent<BoxVariable>();//�t���Ă���X�N���v�g���擾

        //�ʒu�̌덷�C��
        ErrorCorrection();

        //���W�擾
        box_variable.box_pos = parent.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        LocalErrorCorrection();

        // transform���擾
        my_transform = this.transform;

        tf = this.transform;
        save_pos = tf.localPosition;

        //Debug.Log(save_pos);
        //���g�ȊO�̕��������������ꍇ
        if (root_room.room_hit == true)
        {
            
            
            //�ʒu�̌덷�C��
            ErrorCorrection();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //��]�t���O��܂�
            //root_room.rotate_flg = false;

            //�������m����������
            root_room.room_hit = true;
            //Debug.Log("hit");


            ////�Ăѐݒu�ł���悤�ɂ���
            //box_variable.location_flg = true;

            ////Debug.Log("hit"+this);

            ////�ڑ�����Ă邩�H
            ////����������̕ϐ���������
            ////GameObject collision_parent = collision.transform.parent.gameObject;
            ////BoxVariable collision_box_variable = collision_parent.GetComponent<BoxVariable>(); //�t���Ă���X�N���v�g���擾
            ////collision_box_variable.become_child = true;



            ////�ݒu�������Ԃ��폜
            //GameObject[] objects = GameObject.FindGameObjectsWithTag("Gear");
            //foreach (GameObject del in objects)
            //{
            //    Destroy(del);
            //}

            //�ʒu�̌덷�C��
            ErrorCorrection();
        }
    }
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Box"))
    //    {
    //        //��]�t���O��܂�
    //        //root_room.rotate_flg = false;

    //        //�������m����������
    //        root_room.room_hit = true;

    //        //�ʒu�̌덷�C��
    //        ErrorCorrection();
    //    }
    //}

    //�ʒu�̌덷�C��
    void ErrorCorrection()
    {
        //Room�ʒu�̌덷�C��
        Vector3 root_pos = root.transform.position;
        root_pos.x = Mathf.Round(root_pos.x);     //�l�̌ܓ�
        root_pos.y = Mathf.Round(root_pos.y);     //�l�̌ܓ�
        root.transform.position = root_pos;

        // �N�H�[�^�j�I�� �� �I�C���[�p�ւ̕ϊ�
        Vector3 rotationAngles = root.transform.rotation.eulerAngles;

        //�p�x�̌덷�C��
        if ((rotationAngles.z >= 170) && (rotationAngles.z <= 190))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
        }
        else if ((rotationAngles.z >= 80) && (rotationAngles.z <= 100))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
        }
        else if ((rotationAngles.z >= 260) && (rotationAngles.z <= 280))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
        }
        else if ((rotationAngles.z >= -10) && (rotationAngles.z <= 10))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
        }
        else if ((rotationAngles.z >= 350) && (rotationAngles.z <= 370))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360);
        }

        //�e�̈ʒu�̌덷�C��
        Vector3 parent_pos = parent.transform.position;
        parent_pos.x = Mathf.Round(parent_pos.x);     //�l�̌ܓ�
        parent_pos.y = Mathf.Round(parent_pos.y);     //�l�̌ܓ�
        parent.transform.position = parent_pos;

        //Vector3 parent_lpos = parent.transform.localPosition;
        //parent_lpos.x = Mathf.Round(parent_lpos.x);     //�l�̌ܓ�
        //parent_lpos.y = Mathf.Round(parent_lpos.y);     //�l�̌ܓ�
        //parent.transform.localPosition = parent_lpos;

        //�ǂ̈ʒu�̌덷�C��
        //Vector3 my_pos = this.transform.position;
        //my_pos.x = my_pos.x * 100000;
        //my_pos.y = my_pos.y * 100000;

        //my_pos.x = Mathf.Floor(my_pos.x) / 100000;
        //my_pos.y = Mathf.Floor(my_pos.y) / 100000;

        //this.transform.position = my_pos;
    }
    void LocalErrorCorrection()
    {
        Vector3 pos = this.transform.localPosition;

        pos = save_pos;



        if ((pos.y < 0.0001) && (pos.y > -0.0001))
        {
            pos.y = 0;
        }
        if ((pos.x < 0.0001) && (pos.x > -0.0001))
        {
            pos.x = 0;
        }

        this.transform.localPosition = pos;

        //my_pos.x = Mathf.Floor(my_pos.x) / 100000;
        //my_pos.y = Mathf.Floor(my_pos.y) / 100000;

        //this.transform.position = my_pos;
    }
}