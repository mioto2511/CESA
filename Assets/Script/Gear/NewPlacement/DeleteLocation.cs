using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLocation : MonoBehaviour
{
    //BoxVariable�̕ϐ����g��
    private BoxVariable box_variable;
    //GenerateInstallation�̕ϐ����g��
    private GenerateInstallation generate_installation;

    // Start is called before the first frame update
    void Start()
    {
        generate_installation = GetComponent<GenerateInstallation>();//�t���Ă���X�N���v�g���擾

        GameObject obj = transform.parent.gameObject;//�I�u�W�F�N�g��T��
        box_variable = obj.GetComponent<BoxVariable>();//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if(box_variable.delete_flg == true)
        {
            //�ݒu�p�̃I�u�W�F�N�g���폜
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Select");
            foreach (GameObject del in objects)
            {
                Destroy(del);
            }

            //�폜�t���O��܂�
            box_variable.delete_flg = false;

            //�Ăѐݒu�ł���悤�ɂ���
            generate_installation.location_flg = true;
        }
    }
}
