using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParent : MonoBehaviour
{
    //RoomCollition�̕ϐ����g��
    private RoomCollition room_collition;
    //BoxVariable�̕ϐ����g��
    private BoxVariable box_variable;

    //�e�I�u�W�F�N�g
    private GameObject parent;

    private WallHit wall_hit;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject; //�I�u�W�F�N�g��T��

        GameObject obj = transform.parent.gameObject;//�I�u�W�F�N�g��T��
        box_variable = obj.GetComponent<BoxVariable>();//�t���Ă���X�N���v�g���擾

        wall_hit = GetComponent<WallHit>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score.score);
        if (box_variable.become_child == true)
        {
            //�e
            GameObject parent = this.transform.parent.gameObject;

            //�^�O�ύX
            parent.tag = "ActiveBox";

            //�e�̐e��Room�ɂ���
            parent.transform.parent = GameObject.Find("Room").transform;

            //�X�N���v�g��ǉ�
            gameObject.AddComponent<RoomCollition>();

            //�ǑS�ĂɃX�N���v�g��ǉ����邽�߂̃J�E���g
            box_variable.child_cnt++;

            //4�̖ڂ̕ǂ̎��t���O��܂�
            if (box_variable.child_cnt >= 4)
            {
                box_variable.become_child = false;
            }

            // �N�H�[�^�j�I�� �� �I�C���[�p�ւ̕ϊ�
            Vector3 rotationAngles = parent.transform.rotation.eulerAngles;
            //�p�x�̌덷�C��
            if ((rotationAngles.z >= 170) && (rotationAngles.z <= 190))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
            }
            else if ((rotationAngles.z >= 80) && (rotationAngles.z <= 100))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
            }
            else if ((rotationAngles.z >= 260) && (rotationAngles.z <= 280))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
            }
            else if ((rotationAngles.z >= -10) && (rotationAngles.z <= 10))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
            }
            else if ((rotationAngles.z >= 350) && (rotationAngles.z <= 370))
            {
                parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360);
            }

            Destroy(wall_hit);

            //���̃X�N���v�g���폜
            Destroy(this);
        }
    }
}
