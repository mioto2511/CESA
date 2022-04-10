using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStart : MonoBehaviour
{
    //MoveCursor
    private MoveCursor move_cursor;
    //CursorCollision�̕ϐ����g��
    private CursorCollision cursor_colition;
    //MoveAxisOfRotate
    MoveAxisOfRotate move_axis;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
        //move_cursor = obj.GetComponent<MoveCursor>();�@//�t���Ă���X�N���v�g���擾

        cursor_colition = GetComponent<CursorCollision>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //�I�u�W�F�N�g��T��
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            if (cursor_colition.cursor_hit)
            {
                if (this.transform.tag == "ActiveBox")
                {
                    move_axis.move_flg = true;

                    GameObject cursor = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
                    cursor.SetActive(false);
                }
            }
        }
    }
}
