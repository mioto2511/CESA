using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateInstallation : MonoBehaviour
{
    //FulcrumDistance�̕ϐ����g��
    private FulcrumDistance fulcrum_distance;
    //BoxVariable�̕ϐ����g��
    private BoxVariable box_variable;
    //MoveCursor
    private MoveCursor move_cursor;
    //CursorCollision�̕ϐ����g��
    private CursorCollision cursor_colition;

    [SerializeField, Tooltip("��������ݒu�ʒu")]
    private GameObject installation_location;

    [SerializeField, Tooltip("��������J�[�\��")]
    private GameObject cursor;

    //[SerializeField, Tooltip("Drive��Player�̋���")]
    //private float distance = 0;

    //�e
    private GameObject parent_obj;

    // Start is called before the first frame update
    void Start()
    {
        fulcrum_distance = GetComponent<FulcrumDistance>();//�t���Ă���X�N���v�g���擾
        
        //�e���擾
        parent_obj = transform.parent.gameObject;

        box_variable = parent_obj.GetComponent<BoxVariable>();//�t���Ă���X�N���v�g���擾

        GameObject obj = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
        move_cursor = obj.GetComponent<MoveCursor>();�@//�t���Ă���X�N���v�g���擾

        cursor_colition = GetComponent<CursorCollision>();�@//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            //float tmpDis = 0;           //�����p�ꎞ�ϐ�
            //GameObject player = GameObject.Find("Player");//�v���C���[�擾

            ////���g�Ǝ擾�����I�u�W�F�N�g�̋������擾
            //tmpDis = Vector3.Distance(player.transform.position, this.transform.position);

            //if (tmpDis < distance)
            //{
            //    Generate();
            //}

            if (cursor_colition.cursor_hit)
            {
                if(this.transform.tag == "RDrive")
                {
                    Generate();
                    
                }
                else if (this.transform.tag == "LDrive")
                {
                    Generate();
                }

            }
        } 
    }

    void Generate()
    {
        //����
        if (box_variable.location_flg == true)
        {
            // �x�_���擾
            Transform[] installation_transform = new Transform[4];
            Vector3[] installation_pos = new Vector3[4];
            GameObject[] near_obj = new GameObject[4];

            //Drive�ɋ߂��l�̎x�_���擾
            near_obj = fulcrum_distance.serchTag(gameObject, "FulcrumGear");

            // �擾
            Transform my_transform = parent_obj.transform;
            Vector3 my_pos = my_transform.position;

            //�ݒu���W
            Vector3[] center_pos = new Vector3[4];

            //�e�ɂ���
            var parent = parent_obj.transform;

            //4�ӏ��̈ʒu�擾
            for (int i = 0; i < installation_transform.Length; i++)
            {
                //�x�_�̍��W
                installation_transform[i] = near_obj[i].transform;
                installation_pos[i] = installation_transform[i].position;

                //�ݒu���W
                center_pos[i] = (my_pos + installation_pos[i]) / 2;

                //����
                GameObject location_obj = Instantiate(installation_location, new Vector3(center_pos[i].x, center_pos[i].y, 0), Quaternion.identity, parent);
                location_obj.transform.localScale = new Vector3(0.375f, 0.375f, 0);

            }

            //�ݒu�t���O��܂�
            box_variable.location_flg = false;

            //�J�[�\����hit�t���O��܂�
            cursor_colition.cursor_hit = false;

            //�J�[�\���̃^�O�ύX
            GameObject obj = GameObject.Find("SelectCursor"); //�I�u�W�F�N�g��T��
            obj.tag = "Select";

            //����
            //GameObject cursor_obj = Instantiate(cursor, new Vector3(my_pos.x, my_pos.y, 0), Quaternion.identity, parent);
            //cursor_obj.transform.localScale = new Vector3(0.275f, 0.275f, 0);
        }
    }
}
