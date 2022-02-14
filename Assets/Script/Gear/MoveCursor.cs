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
        //Transformを取得
        tf = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveflg == true)
        {
            float lsh = Input.GetAxis("L_Stick_H");//横軸
            float lsv = Input.GetAxis("L_Stick_V");//縦軸

            if (lsh < -0.5)
            {
                tf.position = tf.position + new Vector3(-speed, 0.0f, 0.0f); //カメラを左へ移動。
            }
            else if (lsh > 0.5)
            {
                tf.position = tf.position + new Vector3(+speed, 0.0f, 0.0f); //カメラを左へ移動。
            }


            if (lsv > 0.5) //Iキーが押されていれば
            {
                tf.position = tf.position + new Vector3(0.0f, +speed, 0.0f); //カメラを左へ移動。
            }
            else if (lsv < -0.5) //Iキーが押されていれば
            {
                tf.position = tf.position + new Vector3(0.0f, -speed, 0.0f); //カメラを左へ移動。
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
