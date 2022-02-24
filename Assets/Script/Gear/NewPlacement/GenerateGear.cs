using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGear : MonoBehaviour
{
    //��������I�u�W�F�N�g
    public GameObject gear;

    //CursorCollision�̕ϐ����g��
    CursorCollision cursor_collision;
    //DeleteLocation�̕ϐ����g��
    DeleteLocation delete_location;

    private GameObject parent_obj;

    // Start is called before the first frame update
    void Start()
    {
        //�X�N���v�g���擾
        cursor_collision = GetComponent<CursorCollision>();

        GameObject obj = transform.parent.gameObject;
        delete_location = obj.GetComponent<DeleteLocation>();

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

                Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity,parent);

                //�ݒu�p�̃I�u�W�F�N�g���폜
                delete_location.delete_flg = true;
            }
        }
    }
}
