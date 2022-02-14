using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTransparentGear : MonoBehaviour
{
    //��������I�u�W�F�N�g
    public GameObject TransparentGear;
    public GameObject CursorGear;

    //CursorColition�̕ϐ����g��
    CursorColition cursor_colition;
    //MoveCursor�ϐ����g��
    MoveCursor move_cursor;

    //�����t���O
    public bool generateflg = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
        move_cursor = obj.GetComponent<MoveCursor>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        //�ϐ����g����p�ɂ���
        cursor_colition = GetComponent<CursorColition>();

        // transform���擾
        Transform myTransform = this.transform;

        //vector3�ɕϊ�
        Vector3 pos = myTransform.position;

        //�e�ɂ���
        var parent = this.transform;

        //�{�^���������Ǝ���ɐ���
        if (Input.GetKeyDown("joystick button 0"))
        {
            if(cursor_colition.cursorhit == true)
            {
                if (generateflg == true)
                {
                    //�㉺���E�ɐ���
                    Instantiate(TransparentGear, new Vector3(pos.x + 1.0F, pos.y, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x, pos.y + 1.0F, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x - 1.0F, pos.y, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x, pos.y - 1.0F, 0), Quaternion.identity, parent);
                    //�΂߂ɐ���
                    Instantiate(TransparentGear, new Vector3(pos.x + 0.7F, pos.y + 0.7F, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x + 0.7F, pos.y - 0.7F, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x - 0.7F, pos.y + 0.7F, 0), Quaternion.identity, parent);
                    Instantiate(TransparentGear, new Vector3(pos.x - 0.7F, pos.y - 0.7F, 0), Quaternion.identity, parent);
                    //�J�[�\������
                    Instantiate(CursorGear, new Vector3(pos.x, pos.y, 0), Quaternion.identity, parent);

                    //�������t���O��܂�
                    generateflg = false;

                    //�J�[�\���𓮂��Ȃ�����
                    move_cursor.moveflg = false;
                }
            }
            
        }
    }
}
