using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGear : MonoBehaviour
{
    [SerializeField, Tooltip("�������鎕��")]
    private GameObject gear;

    //�폜�p
    private BoxVariable box_variable;

    //SelectCursorCollision�̕ϐ����g��
    private SelectCursorCollision select_cursor_collision;
    //DeleteLocation�̕ϐ����g��
    private DeleteLocation delete_location;
    //RotateRoom�̕ϐ����g��
    private RotateRoom rotate_room;

    //�e
    private GameObject parent_obj;
    private GameObject root_obj;

    // Start is called before the first frame update
    void Start()
    {
        //�e���擾
        parent_obj = transform.parent.gameObject;
        root_obj = transform.root.gameObject;

        select_cursor_collision = GetComponent<SelectCursorCollision>();//�t���Ă���X�N���v�g���擾

        //GameObject obj = transform.parent.gameObject;//�I�u�W�F�N�g��T��
        box_variable = parent_obj.GetComponent<BoxVariable>();//�t���Ă���X�N���v�g���擾

        rotate_room = root_obj.GetComponent<RotateRoom>();//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        //vector3�ɕϊ�
        Vector3 pos = myTransform.position;

        if (Input.GetKeyDown("joystick button 5"))//�E
        {
            if(select_cursor_collision.cursor_hit == true)
            {
                //�E��]
                rotate_room.right_rotate = true;

                //�e�ɂ���
                var parent = parent_obj.transform;

                GameObject gear_obj =Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity,parent);
                //���̂�����������ύX�i���쒼���j
                //�X�P�[���ύX
                gear_obj.transform.localScale = new Vector3(0.0359f, 0.0359f, 0);
                //�ݒu�p�̃I�u�W�F�N�g���폜
                box_variable.delete_flg = true;
            }
        }
        else if (Input.GetKeyDown("joystick button 4"))//��
        {
            if (select_cursor_collision.cursor_hit == true)
            {
                //�E��]
                rotate_room.left_rotate = true;

                //�e�ɂ���
                var parent = parent_obj.transform;

                GameObject gear_obj = Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity, parent);
                //���̂�����������ύX�i���쒼���j
                //�X�P�[���ύX
                gear_obj.transform.localScale = new Vector3(0.0359f, 0.0359f, 0);
                //�ݒu�p�̃I�u�W�F�N�g���폜
                box_variable.delete_flg = true;
            }
        }
    }
}
