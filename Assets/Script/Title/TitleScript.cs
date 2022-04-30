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
        GameObject L = GameObject.Find("ShutterL"); // オブジェクトを探す
        shutterL = L.GetComponent<Shutter>();

        GameObject R = GameObject.Find("ShutterR"); // オブジェクトを探す
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
