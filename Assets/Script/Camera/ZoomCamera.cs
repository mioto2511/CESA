using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomCamera : MonoBehaviour
{
    [Header("�Y�[�����鎞��")]public int time = 500;

    [Header("�Y�[�����鑬��")] public float speed = 0.01f;

    [Header("�Y�[������V���b�^�[����")] public int shutter_time = 600;

    [Header("�Y�[������V���b�^�[����")] public float shutter_speed = 0.0022f;

    private Camera cam;

    private int count = 0;

    private int shutter_count = 0;

    public bool zoom_flg = false;

    public bool zoom_shutter_flg = false;

    public int next_scene = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();//Camera�擾
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= time)
        {
            zoom_flg = false;
            Fade_Manager.FadeOut(next_scene);
        }

        if (shutter_count >= shutter_time)
        {
            zoom_shutter_flg = false;
            //Fade_Manager.FadeOut(next_scene);
        }
    }

    private void FixedUpdate()
    {
        if (zoom_flg)
        {
            cam.orthographicSize = cam.orthographicSize - speed;
            count++;
        }

        if (zoom_shutter_flg)
        {
            cam.orthographicSize = cam.orthographicSize - shutter_speed;
            shutter_count++;
        }

    }
}
