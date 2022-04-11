using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    

    [Header("�J�[�\���̑���")] public float speed;
    
    [Header("�J�[�\���̃f�b�g�]�[��")] public float deadzone;

    //���g��tf
    private Transform tf;

    //�J�[�\���̈ړ��t���O
    public bool moveflg = true;

    //XY�̑���
    private float speed_x = 0;
    private float speed_y = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Transform���擾
        tf = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveflg == true)
        {
            float lsh = Input.GetAxis("L_Stick_H");//����
            float lsv = Input.GetAxis("L_Stick_V");//�c��

            if (lsh < -deadzone)
            {
                speed_x = -speed;
            }
            else if (lsh > deadzone)
            {
                speed_x = speed;
            }
            else if(lsh == 0)
            {
                speed_x = 0;
            }


            if (lsv > deadzone)
            {
                speed_y = speed;
            }
            else if (lsv < -deadzone)
            {
                speed_y = -speed;
            }
            else if(lsv == 0)
            {
                speed_y = 0;
            }
        }
    }

    void FixedUpdate()
    {
        tf.position = tf.position + new Vector3(speed_x, speed_y, 0.0f);
    }
}
