using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class AutoPlayerMove : MonoBehaviour
{
    private Rigidbody2D rb = null;

    public bool move_flg = true;

    [Header("�L�����̑���")] public float speed;

    //���݂̌���
    private bool right_f = true;

    //����t���O
    public bool isSlip = false;

    //�X�N���v�g�擾
    [Header("�ǐڐG����")] public PlayerWallTrigger wall_trigger;
    [Header("���ڐG����")] public PlayerGroundTrigger ground_trigger;

    //�X�P�[���ۑ�
    private Vector3 tf_s;

    //�S�[���֌������t���O
    public bool to_goal = false;

    //�S�[��
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Goal 1/DriveGear");

        rb = GetComponent<Rigidbody2D>();

        tf_s = transform.localScale;

        isSlip = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (to_goal)
        {
            Vector3 p_pos = this.transform.position;
            Vector3 t_pos = target.transform.position;

            //�S�[�����E�Ȃ獶������
            if(p_pos.x > t_pos.x)
            {
                right_f = false;
            }
            else if(p_pos.x < t_pos.x)
            {
                right_f = true;
            }
        }
        else if (move_flg)
        {
            float xSpeed = 0.0f;

            //�ǂɏՓ˂���������ύX
            if (wall_trigger.isOn)
            {
                right_f = !right_f;
            }

            //�n�ʂ̒[�Ō����ύX
            if (ground_trigger.IsGround() == false && isSlip == false)
            {
                right_f = !right_f;
            }

            //�E����
            if (right_f)
            {
                //�i�s����
                xSpeed = speed;
                //����
                transform.localScale = new Vector3(tf_s.x, tf_s.y, 1);
            }
            //������
            else
            {
                xSpeed = -speed;
                transform.localScale = new Vector3(-tf_s.x, tf_s.y, 1);
            }

            //���
            rb.velocity = new Vector2(xSpeed, rb.velocity.y);
        }
        
    }
}
