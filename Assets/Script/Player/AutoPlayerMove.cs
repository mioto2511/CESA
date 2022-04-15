using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayerMove : MonoBehaviour
{
    private Rigidbody2D rb = null;

    public bool move_flg = true;

    [Header("�L�����̑���")] public float speed;

    //���݂̌���
    private bool right_f = true;

    //�X�N���v�g�擾
    [Header("�ǐڐG����")] public PlayerWallTrigger wall_trigger;
    [Header("���ڐG����")] public PlayerGroundTrigger ground_trigger;

    //�X�P�[���ۑ�
    Vector3 tf_s;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tf_s = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move_flg)
        {
            float xSpeed = 0.0f;

            //�ǂɏՓ˂���������ύX
            if (wall_trigger.isOn)
            {
                right_f = !right_f;
            }

            //�n�ʂ̒[�Ō����ύX
            if (ground_trigger.isOn == false)
            {
                right_f = !right_f;
            }

            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    xSpeed = -speed;
            //}
            //// �E�Ɉړ�
            //else if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    xSpeed = speed;
            //}
            //else
            //{
            //    xSpeed = 0.0f;
            //}

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