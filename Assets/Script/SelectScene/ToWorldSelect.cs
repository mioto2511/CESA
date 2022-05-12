using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWorldSelect : MonoBehaviour
{
    private Shutter shutter;
    private ChangeScene change_scene;

    private int scene = 1;

    private bool button_flg = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<Shutter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button_flg)
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                button_flg = false;

                shutter.shutter_flg = true;

                change_scene.NextScene(scene);
            }
        }
    }
}
