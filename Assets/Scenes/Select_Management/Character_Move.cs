using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    [Header("�ړ��o�H")] public GameObject[] movePoint;
    [Header("����")] public float speed = 1.0f;

    private Rigidbody2D rb = null;
    private int nowPoint = 0;
    private bool returnPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        if (movePoint != null && movePoint.Length > 0 && rb != null)
        {
            //�L�����N�^�[���ړ��o�H�̂O�Ԗڂ̈ʒu��
            rb.position = movePoint[0].transform.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �ʏ�ړ�
        if (!returnPoint)
        {
            int nextPoint = nowPoint + 1;

            // �ڕW�̃|�C���g�܂ł̋������͂��ɂȂ�܂ňړ�
            if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
            {
                // ���ݒn���玟�̃|�C���g�ւ̃x�N�g�����v�Z
                Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);
                
                // ���̃|�C���g�ֈړ�
                rb.MovePosition(toVector);
            }
            else
            { //���̃|�C���g���P�i�߂� 
                rb.MovePosition(movePoint[nextPoint].transform.position);
                ++nowPoint;

                // ���ݒn���z��̍Ōゾ�����ꍇ
                if (nowPoint + 1 >= movePoint.Length)
                {
                    returnPoint = true;
                }
            }
        }
        else
        {
            int nextPoint = nowPoint + 1;

            // �ڕW�̃|�C���g�܂ł̋������͂��ɂȂ�܂ňړ�
            if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
            {
                // ���ݒn���玟�̃|�C���g�ւ̃x�N�g�����v�Z
                Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                // ���̃|�C���g�ֈړ�
                rb.MovePosition(toVector);
            }
            else
            { // ���̃|�C���g���P�i�߂� 
                rb.MovePosition(movePoint[nextPoint].transform.position);
                --nowPoint;

                // ���ݒn���z��̍ŏ��������ꍇ
                if (nowPoint <=0)
                {
                    returnPoint = false;
                }
            }
        }
        
    }
}
