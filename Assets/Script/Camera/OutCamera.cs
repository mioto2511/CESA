using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCamera : MonoBehaviour
{
    [Header("ズームするシャッター時間")] public int shutter_time = 600;

    [Header("ズームするシャッター速さ")] public float shutter_speed = 0.0022f;

    private Camera cam;

    private int shutter_count = 0;

    public bool out_flg = false;

    public int next_scene = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();//Camera取得
    }

    // Update is called once per frame
    void Update()
    {
        if (shutter_count >= shutter_time)
        {
            out_flg = false;
            //Fade_Manager.FadeOut(next_scene);
        }
    }

    private void FixedUpdate()
    {
        if (out_flg)
        {
            cam.orthographicSize = cam.orthographicSize + shutter_speed;
            shutter_count++;
        }

    }
}
