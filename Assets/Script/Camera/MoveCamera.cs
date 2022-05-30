using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Transform tf;

    public  float speed = 0.025f;

    private Camera cam;
    public GameObject cplayer;
    private Vector2 pos;
    public int camerazoom = 1;
    public float zoom;
    private bool cflg = true;

    public bool zoom_flg =false;

    // Start is called before the first frame update
    void Start()
    {
        //カメラのTransformを取得
        tf = this.gameObject.GetComponent<Transform>();

        cam = this.gameObject.GetComponent<Camera>();//Camera取得

        pos = cplayer.transform.position;
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

        //if (Input.GetKeyDown("joystick button 2"))
        //{
        //    if (cflg == false)
        //    {
        //        cflg = true;
        //    }
        //    else if (cflg == true)
        //    {
        //        cflg = false;
        //    }
        //}

        switch (GameObject.Find("Room").transform.childCount)
        {
            case 2:
                camerazoom = 2;
                break;

            case 3:
                //cam.orthographicSize = 6.36f;
                camerazoom = 3;
                break;
        }

        if(zoom_flg)
        {
            cflg = false;
        }

        if (cflg == true)
        {
            //pos.x = cplayer.transform.position.x;
            //pos.y = GameObject.Find(PlayerPosition.instance.pPosition).transform.position.y;
            pos = cplayer.transform.position;
            transform.position = new Vector3(pos.x, pos.y + 1.86f, -100);

            if (camerazoom == 1)
            {
                cam.orthographicSize = 4.1f;
            }
            if (camerazoom == 2)
            {
                cam.orthographicSize = 6.2f;
            }
            if (camerazoom == 3)
            {
                cam.orthographicSize = 8.3f;
            }
        }
        //if (cflg == false)
        //{
        //    transform.position = new Vector3(0, 0, -10);
        //    cam.orthographicSize = zoom;
        //}
    }

    private void FixedUpdate()
    {
        if (zoom_flg)
        {
            pos = cplayer.transform.position;
            transform.position = new Vector3(pos.x, pos.y, -100);

            cam.orthographicSize = cam.orthographicSize - speed;

            float si = cam.orthographicSize;

            if (si <= 4.1f)
            {
                zoom_flg = false;
            }
        }
    }
}