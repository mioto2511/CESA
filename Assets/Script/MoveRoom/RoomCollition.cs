using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        root = this.transform.parent.parent.gameObject; //�I�u�W�F�N�g��T��
        root_room = root.GetComponent<RotateRoom>(); //�t���Ă���X�N���v�g���擾

        parent = this.transform.parent.gameObject; //�I�u�W�F�N�g��T��
        box_variable = parent.GetComponent<BoxVariable>();//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        my_transform = this.transform;

        //���g�ȊO�̕��������������ꍇ
        if (root_room.room_hit == true)
        {
            //�ʒu�̌덷�C��
            ErrorCorrection();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Room"))
        {
            //��]�t���O��܂�
            root_room.rotate_flg = false;

            //�������m����������
            root_room.room_hit = true;

            //Debug.Log("hit"+this);

            //�ڑ�����Ă邩�H
            //����������̕ϐ���������
            //GameObject collision_parent = collision.transform.parent.gameObject;
            //BoxVariable collision_box_variable = collision_parent.GetComponent<BoxVariable>(); //�t���Ă���X�N���v�g���擾
            //collision_box_variable.become_child = true;

            

            //�ݒu�������Ԃ��폜
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Gear");
            foreach (GameObject del in objects)
            {
                Destroy(del);
            }

            //�ʒu�̌덷�C��
            ErrorCorrection();
        }
    }

    //�ʒu�̌덷�C��
    void ErrorCorrection()
    {
        // �N�H�[�^�j�I�� �� �I�C���[�p�ւ̕ϊ�
        Vector3 rotationAngles = root.transform.rotation.eulerAngles;

        //Debug.Log(root.transform.rotation.z);
        //parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(parent.transform.rotation.z));

        //�p�x�̌덷�C��
        if ((rotationAngles.z >= 178) && (rotationAngles.z <= 182))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
        }
        else if ((rotationAngles.z >= 88) && (rotationAngles.z <= 92))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
        }
        else if ((rotationAngles.z >= 268) && (rotationAngles.z <= 272))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
        }
        else if ((rotationAngles.z >= -2) && (rotationAngles.z <= 2))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
        }
        else if ((rotationAngles.z >= 358) && (rotationAngles.z <= 362))
        {
            root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360);
        }
        //root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(root.transform.rotation.z));

        //�ʒu�̌덷�C��
        Vector3 my_pos = parent.transform.position;
        my_pos.x = Mathf.Round(my_pos.x);     //�l�̌ܓ�
        my_pos.y = Mathf.Round(my_pos.y);     //�l�̌ܓ�
        parent.transform.position = my_pos;
    }
}