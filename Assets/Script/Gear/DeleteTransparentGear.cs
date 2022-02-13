using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTransparentGear : MonoBehaviour
{
    //GenerateTransparentGear�̕ϐ����g��
    GenerateTransparentGear generate_transparent_gear;

    //CursorCollision�̕ϐ����g��
    CursorCollision cursor_collision;

    // Update is called once per frame
    void Update()
    {
        //�ϐ����g����p�ɂ���
        cursor_collision = GetComponent<CursorCollision>();

        //GenerateTransparentGear�����Ă���I�u�W�F�N�g
        GameObject gear = GameObject.Find("Gear");

        generate_transparent_gear = gear.GetComponent<GenerateTransparentGear>();

        if (Input.GetKeyDown("joystick button 0"))
        {
            //���ԂɐG��Ă��Ȃ�������
            if(cursor_collision.cursorhit == false)
            {
                //�͈͂̐����t���O��false�Ȃ����
                if (generate_transparent_gear.generateflg == false)
                {
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("Select");
                    foreach (GameObject del in objects)
                    {
                        Destroy(del);
                    }

                    Destroy(gameObject);
                }
            }
        }
    }
}
