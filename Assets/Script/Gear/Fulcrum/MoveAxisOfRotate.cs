using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisOfRotate : MonoBehaviour
{
    public bool move_flg;

    public Vector3 axis_pos;

    //RotateRoom�̕ϐ����g��
    RotateRoom rotate_room;
    //AutoPlayerMove�̕ϐ����g��
    AutoPlayerMove auto_player_move;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = GameObject.Find("RotateRoom"); //�I�u�W�F�N�g��T��
        GameObject obj = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_room = obj.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj2 = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flg == true)
        {
            this.transform.position = axis_pos;

            move_flg = false;

            //�v���C���[���~
            auto_player_move.move_flg = false;

            //��]�J�n
            rotate_room.rotate_flg = true;

            //���Ԃ̃R���C�_�[�폜
            GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
            foreach (GameObject num in objects)
            {
                var colliderTest = num.GetComponent<Collider2D>();
                colliderTest.enabled = false;
            }

            objects = GameObject.FindGameObjectsWithTag("RGear");
            foreach (GameObject num in objects)
            {
                var colliderTest = num.GetComponent<Collider2D>();
                colliderTest.enabled = false;
            }

        }
    }
}
