using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisOfRotate : MonoBehaviour
{
    public bool move_flg;

    //public List<Vector3> axis_poses = new List<Vector3>();// ���X�g
    public Vector3[] axis_poses;

    //RotateRoom�̕ϐ����g��
    RotateRoom rotate_room;

    // Start is called before the first frame update
    void Start()
    {
        //�z�񏉊���
        axis_poses = new Vector3[2];

        GameObject obj = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_room = obj.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flg)
        {
            Debug.Log(string.Join(",", axis_poses));

            move_flg = false;

            //��]�J�n
            rotate_room.rotate_flg = true;

            //�x�_�̃R���C�_�[OFF
            rotate_room.collider_flg = false;
        }
    }

    //�z�񒆐g�폜
    public void Delete()
    {
        for (int i = 0; i < axis_poses.Length; i++)
        {
            axis_poses[i] = new Vector3(0, 0, 0);
        }
    }

    //Axis���x�_�ɃZ�b�g
    public void SetAxis(int id)
    {
        if(id == 0)
        {
            //�E
            this.transform.position = axis_poses[0];
        }
        else if(id == 1)
        {
            //��
            this.transform.position = axis_poses[1];
        }
    }
}
