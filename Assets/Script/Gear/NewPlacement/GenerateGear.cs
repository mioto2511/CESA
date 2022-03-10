using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGear : MonoBehaviour
{
    [SerializeField, Tooltip("�������鎕��")]
    private GameObject gear;

    //�폜�p
    private BoxVariable box_variable;

    //CursorCollision�̕ϐ����g��
    private CursorCollision cursor_collision;
    //DeleteLocation�̕ϐ����g��
    private DeleteLocation delete_location;

    //�e
    private GameObject parent_obj;

    // Start is called before the first frame update
    void Start()
    {
        cursor_collision = GetComponent<CursorCollision>();//�t���Ă���X�N���v�g���擾

        GameObject obj = transform.parent.gameObject;//�I�u�W�F�N�g��T��
        box_variable = obj.GetComponent<BoxVariable>();//�t���Ă���X�N���v�g���擾

        //�e���擾
        parent_obj = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        //vector3�ɕϊ�
        Vector3 pos = myTransform.position;

        if (Input.GetKeyDown("joystick button 0"))
        {
            if(cursor_collision.cursorhit == true)
            {
                //�e�ɂ���
                var parent = parent_obj.transform;

                GameObject gear_obj =Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity,parent);
                //���̂�����������ύX�i���쒼���j
                //�X�P�[���ύX
                gear_obj.transform.localScale = new Vector3(0.375f, 0.375f, 0);
                //�ݒu�p�̃I�u�W�F�N�g���폜
                box_variable.delete_flg = true;
            }
        }
    }
}
