using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Transform tf;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //�J������Transform���擾
        tf = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float rsh = Input.GetAxis("R_Stick_H");//����
        float rsv = Input.GetAxis("R_Stick_V");//�c��

        if (rsh < 0)
        {
            tf.position = tf.position + new Vector3(-speed, 0.0f, 0.0f);
        }
        else if (rsh > 0)
        {
            tf.position = tf.position + new Vector3(+speed, 0.0f, 0.0f);
        }


        if (rsv > 0) //I�L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(0.0f, +speed, 0.0f);
        }
        else if (rsv < 0) //I�L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(0.0f, -speed, 0.0f);
        }
    }
}
