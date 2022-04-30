using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterR : MonoBehaviour
{
    private Vector2 pos;
    bool Change_Start = false;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Transform mytransform = this.transform;
        pos = mytransform.position;

        //Aボタンが押されたら開始
        if (Input.GetKeyDown("joystick button 0"))
        {
            Change_Start = true;
        }

        if (Change_Start == true)
        {
            
            if ((pos.x >= 4.4f))
            {
                //Debug.Log("R");
                pos.x -= 0.02f;
                transform.position = new Vector2(pos.x, pos.y);
            }
        }

    }
}
