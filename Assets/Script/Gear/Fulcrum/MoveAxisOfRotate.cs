using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisOfRotate : MonoBehaviour
{
    public bool move_flg;

    public Vector3 axis_pos;

    //RotateRoom�̕ϐ����g��
    RotateRoom rotate_room;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = GameObject.Find("RotateRoom"); //�I�u�W�F�N�g��T��
        GameObject obj = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_room = obj.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flg == true)
        {
            this.transform.position = axis_pos;

            move_flg = false;

            rotate_room.rotate_flg = true;
        }
    }
}
