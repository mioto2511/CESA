using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    private Shutter shutter;

    private bool button_flg = true;


    // Start is called before the first frame update
    void Awake()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        shutter = T.GetComponent<Shutter>();

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (button_flg)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                button_flg = false;

                shutter.shutter_flg = true;
            }
        }

    }
}
