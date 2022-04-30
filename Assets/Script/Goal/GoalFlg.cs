using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlg : MonoBehaviour
{
    public bool goal_flg = false;

    private bool button_flg = false;

    private Shutter shutterL;
    private Shutter shutterR;
    private ChangeScene change_scene;

    private int scene = 2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject L = GameObject.Find("ShutterL"); // �I�u�W�F�N�g��T��
        shutterL = L.GetComponent<Shutter>();

        GameObject R = GameObject.Find("ShutterR"); // �I�u�W�F�N�g��T��
        shutterR = R.GetComponent<Shutter>();

        GameObject T = GameObject.Find("ShutterTrigger"); // �I�u�W�F�N�g��T��
        change_scene = T.GetComponent<ChangeScene>();
    }

    void Update()
    {
        if (goal_flg)
        {
            Invoke("DelayMethod", 0.25f);
        }

        if (button_flg)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                shutterL.shutter_flg = true;
                shutterR.shutter_flg = true;

                change_scene.NextScene(scene);
            }
        }
    }

    //�x������
    private void DelayMethod()
    {
        button_flg = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            goal_flg = true;
        }
    }
}
