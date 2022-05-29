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

    PlayerFall playerFall;

    private GameObject move_check;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("Goal/DriveGear");

        rb = GetComponent<Rigidbody2D>();

        tf_s = transform.localScale;

        isSlip = false;

        move_check = GameObject.Find("BoxTrigger");
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        playerFall = move_check.GetComponent<PlayerFall>();
        if (move_flg)
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
            if (playerFall.fall_flg == false)
            {                 //�E����
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
}
