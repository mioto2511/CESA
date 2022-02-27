using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollition : MonoBehaviour
{
    //RotateRoom�ϐ����g��
    RotateRoom root_room;
    //BoxVariable
    BoxVariable box_variable;

    //���g��tf
    Transform my_transform;

    GameObject parent;
    GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        root = this.transform.parent.parent.gameObject; //�I�u�W�F�N�g��T��
        //root = GameObject.Find("Room");
        root_room = root.GetComponent<RotateRoom>(); //�t���Ă���X�N���v�g���擾

        parent = this.transform.parent.gameObject; //�I�u�W�F�N�g��T��
        box_variable = parent.GetComponent<BoxVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        my_transform = this.transform;

        //Debug.Log(root.transform.rotation.z);

        if(root != null)
        {
            
        }

        if (root_room.room_hit == true)
        {
            //�ʒu�̌덷�C��
            ErrorCorrection();
            //root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(root.transform.rotation.z));
            //if((root.transform.rotation.z >= -1.01f) &&(root.transform.rotation.z <= -0.98f))
            //{
            //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -1);
            //}

            //Vector3 my_pos = parent.transform.position;
            //my_pos.x = Mathf.Round(my_pos.x);     //�l�̌ܓ�
            //my_pos.y = Mathf.Round(my_pos.y);     //�l�̌ܓ�
            //parent.transform.position = my_pos;
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

            
            ////root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(root.transform.rotation.z));


            //Vector3 my_pos = parent.transform.position;
            //my_pos.x = Mathf.Round(my_pos.x);     //�l�̌ܓ�
            //my_pos.y = Mathf.Round(my_pos.y);     //�l�̌ܓ�
            //parent.transform.position = my_pos;
            //Debug.Log(root.transform.rotation.z);
        }
    }

    //�ʒu�̌덷�C��
    void ErrorCorrection()
    {
        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(parent.transform.rotation.z));
        //if ((root.transform.rotation.z >= -1.01f) && (root.transform.rotation.z <= -0.98f))
        //{
        //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
        //}
        //else if ((root.transform.rotation.z >= -0.51f) && (root.transform.rotation.z <= -0.48f))
        //{
        //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
        //}
        //else if ((root.transform.rotation.z <= 1.01f) && (root.transform.rotation.z >= 0.98f))
        //{
        //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -180);
        //}
        //else if ((root.transform.rotation.z <= 0.51f) && (root.transform.rotation.z >= 0.48f))
        //{
        //    root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90);
        //}
        //root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        Vector3 my_pos = parent.transform.position;
        my_pos.x = Mathf.Round(my_pos.x);     //�l�̌ܓ�
        my_pos.y = Mathf.Round(my_pos.y);     //�l�̌ܓ�
        parent.transform.position = my_pos;
    }
}