using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTransparentGear : MonoBehaviour
{
    //GenerateGear�̕ϐ����g��
    GenerateGear2 generate_gear;
    //MoveCursor�ϐ����g��
    MoveCursor move_cursor;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
        move_cursor = obj.GetComponent<MoveCursor>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        //GenerateGear�̕ϐ����g��
        generate_gear = GetComponent<GenerateGear2>();

        if (Input.GetKeyDown("joystick button 0"))
        {
            //�͈͂̐����t���O��false�Ȃ����
            if (generate_gear.generateflg == false)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag("Select");
                foreach (GameObject del in objects)
                {
                    Destroy(del);
                }

                Destroy(gameObject);

                //�J�[�\���������悤�ɂ���
                move_cursor.moveflg = true;
            }
        }
    }
}
