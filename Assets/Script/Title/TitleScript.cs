using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    private Shutter shutter;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        shutter = T.GetComponent<Shutter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            shutter.shutter_flg = true;
        }
    }
}
