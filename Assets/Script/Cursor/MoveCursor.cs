using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    Transform tf;

    public float speed;
    public bool moveflg = true;
    public float deadzone;

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
                tf.position = tf.position + new Vector3(-speed, 0.0f, 0.0f);
            }
            else if (lsh > deadzone)
            {
                tf.position = tf.position + new Vector3(+speed, 0.0f, 0.0f);
            }


            if (lsv > deadzone)
            {
                tf.position = tf.position + new Vector3(0.0f, +speed, 0.0f);
            }
            else if (lsv < -deadzone)
            {
                tf.position = tf.position + new Vector3(0.0f, -speed, 0.0f);
            }
        }
    }
}