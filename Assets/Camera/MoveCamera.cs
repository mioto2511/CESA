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
        if (Input.GetKey(KeyCode.A)) //I�L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(-speed, 0.0f, 0.0f); //�J���������ֈړ��B
        }
        else if (Input.GetKey(KeyCode.D)) //I�L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(+speed, 0.0f, 0.0f); //�J���������ֈړ��B
        }

        if (Input.GetKey(KeyCode.W)) //I�L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(0.0f, +speed, 0.0f); //�J���������ֈړ��B
        }
        else if (Input.GetKey(KeyCode.S)) //I�L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(0.0f, -speed, 0.0f); //�J���������ֈړ��B
        }
    }
}
