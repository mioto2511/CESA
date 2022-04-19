using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterL : MonoBehaviour
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
            SoundManager.Instance.PlaySE(SESoundData.SE.Pick);
        }

        if (Change_Start == true)
        {
            if ((pos.x <= -4.5f))
            {
                //Debug.Log("L");
                pos.x += 0.01f;
                transform.position = new Vector2(pos.x, pos.y);
            }

        }
       
    }
}
