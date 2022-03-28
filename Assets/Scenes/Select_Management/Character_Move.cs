using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    [Header("�ړ��o�H")] public GameObject[] movePoint;
    [Header("����")] public float speed = 1.0f;


    private Rigidbody2D rb = null;
    private int nowPoint = 0;
    private bool PointMax = false;
    private bool PointMin = false;
    private bool RightMove = false;
    private bool LeftMove = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (movePoint != null && movePoint.Length > 0 && rb != null)
        {
            //�L�����N�^�[���ړ��o�H�̂O�Ԗڂ̈ʒu��
            rb.position = movePoint[0].transform.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.RightArrow) && RightMove == false && LeftMove == false && PointMax == false)
        {
            RightMove = true;
            Debug.Log("R");
        }
        if (Input.GetKey(KeyCode.LeftArrow) && RightMove == false && LeftMove == false && PointMin == false)
        {
            LeftMove = true;
            Debug.Log("L");
        }

        if (movePoint != null && movePoint.Length > 1 && rb != null)
        {
            // �ʏ�i�s
            if (RightMove == true)
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
                    ++nowPoint;
                    RightMove = false;

                    
                }
            }
            else if (LeftMove == true)
            {
                int nextPoint = nowPoint - 1;

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
                    LeftMove = false;
                }
            }
            // ���ݒn���z��̍Ōゾ�����ꍇ
            if (nowPoint + 1 >= movePoint.Length)
            {
                PointMax = true;
                Debug.Log("max");
            }
            else
            {
                PointMax = false;
            }
            // ���ݒn���z��̍ŏ��������ꍇ
            if (nowPoint <= 0)
            {
                PointMin = true;
                Debug.Log("min");
            }
            else
            {
                PointMin = false;
            }
        }

    }
}
