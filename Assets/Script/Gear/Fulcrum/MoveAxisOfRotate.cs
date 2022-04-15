using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisOfRotate : MonoBehaviour
{
    public bool move_flg;

    public List<Vector3> axis_poses = new List<Vector3>();// ���X�g
    public Vector3 axis_pos;

    //RotateRoom�̕ϐ����g��
    RotateRoom rotate_room;
    //AutoPlayerMove�̕ϐ����g��
    AutoPlayerMove auto_player_move;

    public bool chang_axis = false;
    private int axis_num = 0;

    public bool delete_list = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_room = obj.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj2 = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flg)
        {
            //Debug.Log(string.Join(",", axis_poses));
            this.transform.position = axis_poses[0];

            //if(axis_poses.Count < 2)
            //{
            //    Vector3 pos = axis_poses[0];
            //    axis_poses.Add(pos);
            //}

            move_flg = false;

            //�v���C���[���~
            auto_player_move.move_flg = false;

            //��]�J�n
            rotate_room.rotate_flg = true;

            rotate_room.collider_flg = false;

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

        if (chang_axis)
        {
            if(axis_num == 0)
            {
                if (axis_poses.Count >= 2)
                {
                    this.transform.position = axis_poses[1];
                    axis_num = 1;
                }
                
            }
            else if (axis_num == 1)
            {
                this.transform.position = axis_poses[0];
                axis_num = 0;
            }

            chang_axis = false;
        }

        if (delete_list)
        {
            delete_list = false;

            axis_poses.Clear();
        }
    }
}
