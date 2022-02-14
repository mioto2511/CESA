using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    Transform tf;

    public float speed;
    private bool moveflg = true;

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

            if (lsh < -0.5)
            {
                tf.position = tf.position + new Vector3(-speed, 0.0f, 0.0f); //�J���������ֈړ��B
            }
            else if (lsh > 0.5)
            {
                tf.position = tf.position + new Vector3(+speed, 0.0f, 0.0f); //�J���������ֈړ��B
            }


            if (lsv > 0.5) //I�L�[��������Ă����
            {
                tf.position = tf.position + new Vector3(0.0f, +speed, 0.0f); //�J���������ֈړ��B
            }
            else if (lsv < -0.5) //I�L�[��������Ă����
            {
                tf.position = tf.position + new Vector3(0.0f, -speed, 0.0f); //�J���������ֈړ��B
            }

            if(Input.GetKeyDown("joystick button 0"))
            {
                moveflg = false;
            }
        }
        else if(moveflg == false)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                moveflg = true;
            }
        }

        
    }
}
