using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRotate : MonoBehaviour
{
    private bool rotate_flg = true;

    private float deadzone = 0.2f;

    private bool up_flg = false;
    private bool down_flg = false;

    private float max_rotate = 45f;
    private float now_rotate = 0;
    private float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate_flg)
        {          
            float lsh = Input.GetAxis("L_Stick_H");//‰¡Ž²
            float lsv = Input.GetAxis("L_Stick_V");//cŽ²

            if(lsv > deadzone)
            {
                up_flg = true;
                rotate_flg = false;
            }
            else if(lsv < -deadzone)
            {
                down_flg = true;
                rotate_flg = false;
            }
        }
    }

    void FixedUpdate()
    {

        if (up_flg)
        {
            this.transform.Rotate(new Vector3(0, 0, -speed));

            now_rotate += -speed;

            Debug.Log(now_rotate);

            if(-max_rotate >= now_rotate)
            {
                up_flg = false;
                now_rotate = 0;
                Invoke("DelayMethod", 0.25f);
            }
        }

        if (down_flg)
        {
            this.transform.Rotate(new Vector3(0, 0, speed));

            now_rotate += speed;

            if (max_rotate <= now_rotate)
            {
                down_flg = false;
                now_rotate = 0;
                Invoke("DelayMethod", 0.25f);
            }
        }
    }

    //’x‰„ˆ—
    private void DelayMethod()
    {
        rotate_flg = true;
    }
}
