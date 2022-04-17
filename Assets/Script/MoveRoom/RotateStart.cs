using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStart : MonoBehaviour
{
    //MoveCursor
    //private MoveCursor move_cursor;
    //CursorCollision�̕ϐ����g��
    //private CursorCollision cursor_colition;
    //AutoPlayerMove�̕ϐ����g��
    private AutoPlayerMove auto_player_move;
    //MoveAxisOfRotate
    private MoveAxisOfRotate move_axis;

    public bool botton_flg = true;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
        //move_cursor = obj.GetComponent<MoveCursor>();�@//�t���Ă���X�N���v�g���擾

        //cursor_colition = GetComponent<CursorCollision>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //�I�u�W�F�N�g��T��
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj2 = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        auto_player_move = obj2.GetComponent<AutoPlayerMove>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            if (botton_flg)
            {
                //if (this.transform.tag == "ActiveBox")
                //{

                //}
                botton_flg = false;
                //���Z�b�g
                move_axis.move_flg = true;

                GameObject cursor = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
                cursor.SetActive(false);

                //�v���C���[���~
                auto_player_move.move_flg = false;

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
        }
    }
}
