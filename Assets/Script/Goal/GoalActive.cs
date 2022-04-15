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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            }

        }
        
    }
}