using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Transform tf;

    public float speed;

    private Camera cam;
    public GameObject room;
    private Vector2 pos;
    private GameObject parent;
    public int camerazoom = 1;
    private bool cflg = false;

    // Start is called before the first frame update
    void Start()
    {
        //カメラのTransformを取得
        tf = this.gameObject.GetComponent<Transform>();

        cam = this.gameObject.GetComponent<Camera>();//Camera取得
    }

    // Update is called once per frame
    void Update()
    {
        //float rsh = Input.GetAxis("R_Stick_H");//横軸
        //float rsv = Input.GetAxis("R_Stick_V");//縦軸

        //if (rsh < 0)
        //{
        //    tf.position = tf.position + new Vector3(-speed, 0.0f, 0.0f);
        //}
        //else if (rsh > 0)
        //{
        //    tf.position = tf.position + new Vector3(+speed, 0.0f, 0.0f);
        //}


        //if (rsv > 0) //Iキーが押されていれば
        //{
        //    tf.position = tf.position + new Vector3(0.0f, +speed, 0.0f);
        //}
        //else if (rsv < 0) //Iキーが押されていれば
        //{
        //    tf.position = tf.position + new Vector3(0.0f, -speed, 0.0f);
        //}

        pos = room.transform.position;
        transform.position = new Vector3(pos.x, pos.y, -10);

        if (Input.GetKeyDown("joystick button 2"))
        {
            if (cflg == false)
            {
                cflg = true;
            }
            else if (cflg == true)
            {
                cflg = false;
            }
        }

        switch (GameObject.Find("Room").transform.childCount)
        {
            case 2:
                camerazoom = 2;
                break;

            case 3:
                camerazoom = 3;
                break;
        }

        if (cflg == true)
        {
            if (camerazoom == 1)
            {
                cam.orthographicSize = 4.2f;
            }
            if (camerazoom == 2)
            {
                cam.orthographicSize = 10.2f;
            }
            if (camerazoom == 3)
            {
                cam.orthographicSize = 16.2f;
            }
        }
        if (cflg == false)
        {
            cam.orthographicSize = 16.2f;
        }
    }
}