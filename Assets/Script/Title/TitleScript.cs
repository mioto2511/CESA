using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    private Shutter shutterL;
    private Shutter shutterR;

    // Start is called before the first frame update
    void Start()
    {
        GameObject L = GameObject.Find("ShutterL"); // �I�u�W�F�N�g��T��
        shutterL = L.GetComponent<Shutter>();

        GameObject R = GameObject.Find("ShutterR"); // �I�u�W�F�N�g��T��
        shutterR = R.GetComponent<Shutter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            shutterL.shutter_flg = true;
            shutterR.shutter_flg = true;
        }
    }
}
