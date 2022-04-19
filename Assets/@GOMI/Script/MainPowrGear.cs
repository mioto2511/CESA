using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPowrGear : MonoBehaviour
{
    //�X�N���v�g�p�ϐ�
    GimmickData gimmick_data;

    // Start is called before the first frame update
    void Start()
    {
        //�����Őe���擾
        GameObject gimmick = this.transform.parent.gameObject;
        //�e�I�u�W�F�N�g�̃X�N���v�g����Q�Ƃ������ϐ�����
        gimmick_data = gimmick.GetComponent<GimmickData>();
    }

    // Update is called once per frame
    void Update()
    {
        //��]�̌����m�F
        Vector3 rotate = transform.localEulerAngles;

        if (Input.GetKey("joystick button 0"))
        {
            gimmick_data.left_rotate = true;
            gimmick_data.right_rotate = false;
            gimmick_data.IsOn = true;
        }
        else if (Input.GetKey("joystick button 1"))
        {
            gimmick_data.right_rotate = true;
            gimmick_data.left_rotate = false;
            gimmick_data.IsOn = true;
        }

        //����]
        if (gimmick_data.left_rotate == true)
        {
            transform.Rotate(new Vector3(0, 0, 2));
        }
        else if (gimmick_data.right_rotate == true)
        {
            transform.Rotate(new Vector3(0, 0, -2));
        }
    }
}
