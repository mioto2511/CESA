 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kari : MonoBehaviour
{
    Transform my_transform;
    Vector3 my_pos;

    //RotateRoom�ϐ����g��
    RotateRoom rotate_room;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("RotateRoom"); //�I�u�W�F�N�g��T��
        rotate_room = obj.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        my_transform = this.transform;

        my_pos = my_transform.position;

        //�{�^���������Ɖ�]
        if (Input.GetKeyDown("joystick button 0"))
        {
            my_pos.x = 1;
            my_pos.y = 1;
            rotate_room.rotate_flg = true;
        }
        //�{�^���������Ɖ�]
        else if (Input.GetKeyDown("joystick button 1"))
        {
            my_pos.x = -1;
            my_pos.y = -1;
            rotate_room.rotate_flg = true;
        }

        my_transform.position = my_pos;
    }
}
