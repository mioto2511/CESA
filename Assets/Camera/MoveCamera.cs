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
        //カメラのTransformを取得
        tf = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) //Iキーが押されていれば
        {
            tf.position = tf.position + new Vector3(-speed, 0.0f, 0.0f); //カメラを左へ移動。
        }
        else if (Input.GetKey(KeyCode.D)) //Iキーが押されていれば
        {
            tf.position = tf.position + new Vector3(+speed, 0.0f, 0.0f); //カメラを左へ移動。
        }

        if (Input.GetKey(KeyCode.W)) //Iキーが押されていれば
        {
            tf.position = tf.position + new Vector3(0.0f, +speed, 0.0f); //カメラを左へ移動。
        }
        else if (Input.GetKey(KeyCode.S)) //Iキーが押されていれば
        {
            tf.position = tf.position + new Vector3(0.0f, -speed, 0.0f); //カメラを左へ移動。
        }
    }
}
