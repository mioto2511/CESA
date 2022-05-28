using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalActive : MonoBehaviour
{
    [SerializeField, Tooltip("��������S�[��")]
    private GameObject goal;

    [SerializeField, Tooltip("�S�[���T�C�Y")]
    private float goal_scale = 0.15f;

    private bool generate_flag = true;

    private RotateStart rotate_start;

    private AutoPlayerMove auto_player_move;

    public bool goal_active = false;

    private GameObject goal_part;

    // Start is called before the first frame update
    void Start()
    {
        GameObject s = GameObject.Find("Room"); // �I�u�W�F�N�g��T��
        rotate_start = s.GetComponent<RotateStart>();

        GameObject p = GameObject.Find("Player");
        auto_player_move = p.GetComponent<AutoPlayerMove>();

        goal_part = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rotate_start.botton_flg);
        if (generate_flag)
        {
            if (this.tag == "RDrive")
            {
                // transform���擾
                Transform myTransform = this.transform;

                //vector3�ɕϊ�
                Vector3 pos = myTransform.position;

                GameObject goal_obj = Instantiate(goal, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                //�X�P�[���ύX
                goal_obj.transform.localScale = new Vector3(goal_scale, goal_scale, 0);

                generate_flag = false;

                //�񂹖�������
                rotate_start.botton_flg = false;

                goal_active = true;

                //�v���C���[���S�[���֌�����
                //auto_player_move.to_goal = true;
            }
            else if (this.tag == "LDrive")
            {
                // transform���擾
                Transform myTransform = this.transform;

                //vector3�ɕϊ�
                Vector3 pos = myTransform.position;

                GameObject goal_obj = Instantiate(goal, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                //�X�P�[���ύX
                goal_obj.transform.localScale = new Vector3(goal_scale, goal_scale, 0);

                generate_flag = false;

                //�񂹖�������
                rotate_start.botton_flg = false;

                goal_active = true;

                //�v���C���[���S�[���֌�����
                //auto_player_move.to_goal = true;

                // Goal�̕����̃p�[�e�B�N����goal_obj�̃p�[�e�B�N���ɐ؂�ւ��邽�ߏ���
                Destroy(goal_part);
            }
        }
    }
}
