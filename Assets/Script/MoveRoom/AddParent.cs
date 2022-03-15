using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParent : MonoBehaviour
{
    //RoomCollition�̕ϐ����g��
    private RoomCollition room_collition;
    //BoxVariable�̕ϐ����g��
    private BoxVariable box_variable;

    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject; //�I�u�W�F�N�g��T��

        GameObject obj = transform.parent.gameObject;//�I�u�W�F�N�g��T��
        box_variable = obj.GetComponent<BoxVariable>();//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (box_variable.become_child == true)
        {
            //�e
            GameObject parent = this.transform.parent.gameObject;

            //Debug.Log("become"+parent);

            //�e�̐e��Room�ɂ���
            parent.transform.parent = GameObject.Find("Room").transform;

            //�X�N���v�g��ǉ�
            gameObject.AddComponent<RoomCollition>();

            //�ǑS�ĂɃX�N���v�g��ǉ����邽�߂̃J�E���g
            box_variable.child_cnt++;

            //4�̖ڂ̕ǂ̎��t���O��܂�
            if (box_variable.child_cnt >= 4)
            {
                

                //ErrorCorrection();
                box_variable.become_child = false;
            }

            //���̃X�N���v�g���폜
            Destroy(this);
        }
    }

    //�ʒu�̌덷�C��
    //void ErrorCorrection()
    //{
        
    //    // �N�H�[�^�j�I�� �� �I�C���[�p�ւ̕ϊ�
    //    Vector3 rotationAngles = parent.transform.rotation.eulerAngles;

    //    Debug.Log(rotationAngles.z);
    //    //Debug.Log(root.transform.rotation.z);
    //    //parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(parent.transform.rotation.z));

    //    //�p�x�̌덷�C��
    //    if ((rotationAngles.z >= 178) && (rotationAngles.z <= 182))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
    //    }
    //    else if ((rotationAngles.z >= 88) && (rotationAngles.z <= 92))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
    //    }
    //    else if ((rotationAngles.z >= 268) && (rotationAngles.z <= 272))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
    //    }
    //    else if ((rotationAngles.z >= -2) && (rotationAngles.z <= 2))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
    //    }
    //    else if ((rotationAngles.z >= 358) && (rotationAngles.z <= 362))
    //    {
    //        parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360);
    //    }
    //    //root.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Round(root.transform.rotation.z));

    //    //�ʒu�̌덷�C��
    //    Vector3 my_pos = parent.transform.position;
    //    my_pos.x = Mathf.Round(my_pos.x);     //�l�̌ܓ�
    //    my_pos.y = Mathf.Round(my_pos.y);     //�l�̌ܓ�
    //    parent.transform.position = my_pos;
    //}
}
