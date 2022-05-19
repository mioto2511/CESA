using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomCamera : MonoBehaviour
{
    [Header("ズームする時間")]public int time = 500;

    [Header("ズームする速さ")] public float speed = 0.01f;

    private Camera cam;

    private int count = 0;

    public bool zoom_flg = false;

    public int next_scene = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();//Camera取得
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= time)
        {
            zoom_flg = false;
            Fade_Manager.FadeOut(next_scene);
        }
    }

    private void FixedUpdate()
    {
        if (zoom_flg)
        {
            cam.orthographicSize = cam.orthographicSize - speed;
            count++;
        }
        
    }
}
