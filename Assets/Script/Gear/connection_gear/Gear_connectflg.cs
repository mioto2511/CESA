using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ڑ����Ԃ�������畔���̐ڑ��t���O���I���ɂ���
public class Gear_connectflg : MonoBehaviour
{
    //BoxVariable�̕ϐ����g��
    private BoxVariable box_variable;
    //RotateRoom�̕ϐ����g��
    private RotateRoom rotate_room;

    private bool flg = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Boxobj = transform.parent.gameObject;
        box_variable = Boxobj.GetComponent<BoxVariable>();

        GameObject obj = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_room = obj.GetComponent<RotateRoom>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "LGear_Connect")
        {
            box_variable.become_child = true;

            if (flg)
            {
                flg = false;
            }
        }
        else if(this.tag == "RGear_Connect")
        {
            box_variable.become_child = true;

            if (flg)
            {
                flg = false;
            }
        }
    }
}
