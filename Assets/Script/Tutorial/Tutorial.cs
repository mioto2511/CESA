using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    public VideoPlayer video_player;

    private GameObject image;
    public GameObject e_image;

    private RotateStart rotate_start;

    private void Awake()
    {
        GameObject obj3 = GameObject.Find("Room");
        rotate_start = obj3.GetComponent<RotateStart>();
        rotate_start.botton_flg = false;

        image = GameObject.Find("Tutorial");

        image.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            rotate_start.botton_flg = true;
            e_image.SetActive(true);
            image.SetActive(false);
        }
    }

}
