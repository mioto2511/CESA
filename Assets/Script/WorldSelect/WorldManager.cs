using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [Header("���[���h�J��")] public bool clear = false;
    [Header("�V�[���r���h�̔ԍ�")] public int World_No = 0;

    private Shutter shutterL;
    private Shutter shutterR;
    private ChangeScene change_scene;

    void Start()
    {
        GameObject L = GameObject.Find("ShutterL"); // �I�u�W�F�N�g��T��
        shutterL = L.GetComponent<Shutter>();

        GameObject R = GameObject.Find("ShutterR"); // �I�u�W�F�N�g��T��
        shutterR = R.GetComponent<Shutter>();

        GameObject T = GameObject.Find("ShutterTrigger"); // �I�u�W�F�N�g��T��
        change_scene = T.GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clear == true)
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }

    public void OnClickStartButton()
    {
        shutterL.shutter_flg = true;
        shutterR.shutter_flg = true;

        change_scene.NextScene(World_No);
    }
}
