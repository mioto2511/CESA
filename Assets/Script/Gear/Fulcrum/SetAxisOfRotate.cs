using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAxisOfRotate : MonoBehaviour
{
    //GearCollision�̕ϐ����g��
    GearCollision gear_collision;
    //MoveAxisOfRotate
    MoveAxisOfRotate move_axis;

    // Start is called before the first frame update
    void Start()
    {
        gear_collision = GetComponent<GearCollision>(); //�X�N���v�g���擾

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //�I�u�W�F�N�g��T��
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if(gear_collision.gear_hit == true)
        {
            //���g���擾
            Vector3 my_pos = this.transform.position;

            //�x�_�Ɉړ�������
            move_axis.axis_pos = my_pos;

            //�x�_���ړ�������
            move_axis.move_flg = true;

            gear_collision.gear_hit = false;
        }
    }
}
