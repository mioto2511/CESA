using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRotate : MonoBehaviour
{
    private bool rotate_flg = true;

    private float deadzone = 0.2f;

    private bool up_flg = false;
    private bool down_flg = false;

    private float max_rotate = 45f;
    private float now_rotate = 0;
    private float speed = 0.1f;

    //�X�e�b�N�̊J�n�n�_
    private float start_radian = 0;

    //�X�e�b�N�̑O��p�x
    private float old_radian = 0;

    //�����ʒu�t���O
    private bool initial_flg = true;

    // Update is called once per frame
    void Update()
    {
        if (rotate_flg)
        {          
            float lsh = Input.GetAxis("L_Stick_H");//����
            float lsv = Input.GetAxis("L_Stick_V");//�c��

            //if(lsv > deadzone)
            //{
            //    up_flg = true;
            //    rotate_flg = false;
            //}
            //else if(lsv < -deadzone)
            //{
            //    down_flg = true;
            //    rotate_flg = false;
            //}

            //�X�e�b�N�̊p�x�Y�o
            float radian = Mathf.Atan2(lsv, lsh) * Mathf.Rad2Deg;
            if (radian < 0)
            {
                radian += 360;
            }
            //�X�e�B�b�N���͂��͂�������
            if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
            {
                //�����ʒu�̎�
                if (initial_flg)
                {
                    initial_flg = false;

                    //�X�e�B�b�N�̊J�n�p�x
                    start_radian = radian;

                }


                if (up_flg == false && down_flg == false)
                {
                    float now_radian = start_radian - radian;

                    //0�`360�Ŕ�Ԃ̂����P
                    if (old_radian >= 0 && now_radian < -200)
                    {
                        now_radian += 360;
                    }
                    else if (old_radian <= 0 && now_radian > 200)
                    {
                        now_radian -= 360;
                    }

                    //90�x��]�������]�J�n
                    if (now_radian >= 90)
                    { 
                        up_flg = true;

                        rotate_flg = false;

                        initial_flg = true;
                    }
                    else if (now_radian <= -90)
                    {
                        down_flg = true;

                        rotate_flg = false;

                        initial_flg = true;
                    }

                    //�ۑ�
                    old_radian = now_radian;
                }
            }
            else if (lsh == 0 && lsv == 0)
            {
                //��]�����ʒu�̏�����
                start_radian = 0;
                old_radian = 0;
                initial_flg = true;
            }
        }
    }

    void FixedUpdate()
    {

        if (up_flg)
        {
            this.transform.Rotate(new Vector3(0, 0, -speed));

            now_rotate += -speed;

            if(-max_rotate >= now_rotate)
            {
                up_flg = false;
                now_rotate = 0;
                Invoke("DelayMethod", 0.25f);
            }
        }

        if (down_flg)
        {
            this.transform.Rotate(new Vector3(0, 0, speed));

            now_rotate += speed;

            if (max_rotate <= now_rotate)
            {
                down_flg = false;
                now_rotate = 0;
                Invoke("DelayMethod", 0.25f);
            }
        }
    }

    //�x������
    private void DelayMethod()
    {
        rotate_flg = true;
    }
}
