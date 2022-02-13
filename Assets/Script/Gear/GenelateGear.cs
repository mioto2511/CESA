using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenelateGear : MonoBehaviour
{
    public GameObject gear;

    GameObject cursor;

    //�����t���O
    public bool GenerateFlg = true;

    //CursorCollision�̕ϐ����g��
    CursorCollision cursor_collision;

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        //vector3�ɕϊ�
        Vector3 pos = myTransform.position;

        //�ϐ����g����p�ɂ���
        cursor_collision = GetComponent<CursorCollision>();

        //�J�[�\����������
        cursor = GameObject.Find("Cursor");

        if (Input.GetKeyDown("joystick button 0"))
        {
            //�ق��̎��Ԃɓ������ĂȂ��Ȃ�
            if(cursor_collision.cursorhit == false)
            {
                if (GenerateFlg == true)
                {
                    Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                }
            }
        }
    }
}
