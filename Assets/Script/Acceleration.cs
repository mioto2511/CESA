using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    private bool acceleration_flg = true;

    public bool button_flg = true;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(acceleration_flg);

        if (button_flg)
        {
            if (acceleration_flg)
            {
                if (Input.GetKeyDown("joystick button 1"))
                {
                    Time.timeScale = 2f;
                    acceleration_flg = false;
                }
            }
            else
            {
                if (Input.GetKeyDown("joystick button 1"))
                {
                    Time.timeScale = 1f;
                    acceleration_flg = true;
                }
            }
        }   
    }
}
