using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollition : MonoBehaviour
{
    //RotateRoom�ϐ����g��
    RotateRoom rotate_room;
    //ParentRoom�ϐ����g��
    ParentRoom parent_room;

    //���g��tf
    Transform my_transform;

    //�q�ɂȂ�t���O
    public bool become_child = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("RotateRoom"); //�I�u�W�F�N�g��T��
        rotate_room = obj.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj1 = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        parent_room = obj1.GetComponent<ParentRoom>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        my_transform = this.transform;

        if(parent_room.room_hit == true)
        {
            //�ʒu�̌덷�C��
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            Vector3 my_pos = this.transform.position;

            my_pos.x = Mathf.Round(my_pos.x);     //�l�̌ܓ�
            my_pos.y = Mathf.Round(my_pos.y);     //�l�̌ܓ�

            this.transform.position = my_pos;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Room"))
        {
            
            if (rotate_room.rotate_flg == true)
            {
                Debug.Log(this);
                
            }
            //��]�t���O��܂�
            rotate_room.rotate_flg = false;

            //�������m����������
            parent_room.room_hit = true;

            become_child = true;

            //�ݒu�������Ԃ��폜
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Gear");
            foreach (GameObject del in objects)
            {
                Destroy(del);
            }

            //�ʒu�̌덷�C��
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            Vector3 my_pos = this.transform.position;

            my_pos.x = Mathf.Round(my_pos.x);     //�l�̌ܓ�
            my_pos.y = Mathf.Round(my_pos.y);     //�l�̌ܓ�

            this.transform.position = my_pos;
        }
    }
}
