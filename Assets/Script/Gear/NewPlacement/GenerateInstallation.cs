using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateInstallation : MonoBehaviour
{
    //FulcrumDistance�̕ϐ����g��
    FulcrumDistance fulcrum_distance;

    //��������I�u�W�F�N�g
    public GameObject installation_location;
    public GameObject cursor;

    public bool location_flg = true;

    // Start is called before the first frame update
    void Start()
    {
        //�X�N���v�g���擾
        fulcrum_distance = GetComponent<FulcrumDistance>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            if(location_flg == true)
            {
                // �x�_���擾
                Transform[] installation_transform = new Transform[4];
                Vector3[] installation_pos = new Vector3[4];

                // �擾
                Transform my_transform = this.transform;
                Vector3 my_pos = my_transform.position;

                //�ݒu���W
                Vector3[] center_pos = new Vector3[4];

                //�e�ɂ���
                var parent = this.transform;

                //4�ӏ��̈ʒu�擾
                for (int i = 0; i < installation_transform.Length; i++)
                {
                    //�x�_�̍��W
                    installation_transform[i] = fulcrum_distance.near_obj[i].transform;
                    installation_pos[i] = installation_transform[i].position;

                    //�ݒu���W
                    center_pos[i] = (my_pos + installation_pos[i]) / 2;

                    //����
                    Instantiate(installation_location, new Vector3(center_pos[i].x, center_pos[i].y, 0), Quaternion.identity, parent);

                    location_flg = false;
                }

                //����
                Instantiate(cursor, new Vector3(my_pos.x, my_pos.y, 0), Quaternion.identity, parent);
            }
            
        }
    }
}
