using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWorldSelect : MonoBehaviour
{
    private Shutter shutterL;
    private Shutter shutterR;
    private ChangeScene change_scene;

    private int scene = 1;

    // Start is called before the first frame update
    void Start()
    {
        GameObject L = GameObject.Find("ShutterL"); // オブジェクトを探す
        shutterL = L.GetComponent<Shutter>();

        GameObject R = GameObject.Find("ShutterR"); // オブジェクトを探す
        shutterR = R.GetComponent<Shutter>();

        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        change_scene = T.GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 7"))
        {
            shutterL.shutter_flg = true;
            shutterR.shutter_flg = true;

            change_scene.NextScene(scene);
        }
    }
}
