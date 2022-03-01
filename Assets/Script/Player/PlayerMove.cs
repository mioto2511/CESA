using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform tf;

    public float speed;
    public float camera_speed;
    public bool moveflg = true;
    public float deadzone;


    // Start is called before the first frame update
    void Start()
    {
        //TransformπζΎ
        tf = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveflg == true)
        {
            float lsh = Input.GetAxis("L_Stick_H");//‘²
            float lsv = Input.GetAxis("L_Stick_V");//c²

            if (lsh < -deadzone)
            {
                tf.position = tf.position + new Vector3(-speed, 0.0f, 0.0f);
            }
            else if (lsh > deadzone)
            {
                tf.position = tf.position + new Vector3(+speed, 0.0f, 0.0f);
            }


            //if (lsv > deadzone)
            //{
            //    tf.position = tf.position + new Vector3(0.0f, +speed, 0.0f);
            //}
            //else if (lsv < -deadzone)
            //{
            //    tf.position = tf.position + new Vector3(0.0f, -speed, 0.0f);
            //}
        }

        //J[\ͺJΙΗ]
        //float rsh = Input.GetAxis("R_Stick_H");//‘²
        //float rsv = Input.GetAxis("R_Stick_V");//c²

        //if (rsh < 0)
        //{
        //    tf.position = tf.position + new Vector3(-camera_speed, 0.0f, 0.0f);
        //}
        //else if (rsh > 0)
        //{
        //    tf.position = tf.position + new Vector3(+camera_speed, 0.0f, 0.0f);
        //}


        //if (rsv > 0)
        //{
        //    tf.position = tf.position + new Vector3(0.0f, +camera_speed, 0.0f);
        //}
        //else if (rsv < 0)
        //{
        //    tf.position = tf.position + new Vector3(0.0f, -camera_speed, 0.0f);
        //}
    }
}
