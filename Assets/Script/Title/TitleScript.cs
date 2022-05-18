using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    private Shutter shutter;

    private bool button_flg = true;

    [Header("ループ時間")]public float speed = 1.0f;

    public Text text;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        shutter = T.GetComponent<Shutter>();
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

        text.color = GetAlphaColor(text.color);
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}
