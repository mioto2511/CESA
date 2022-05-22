using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelect : MonoBehaviour
{
    private Shutter shutter;
    private ChangeScene change_scene;

    [Header("�|�[�Y����̃Z���N�g")] public int scene = 2;

    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // �I�u�W�F�N�g��T��
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<Shutter>();
    }

    public void OnClickStartButton()
    {
        shutter.shutter_flg = true;

        //change_scene.NextScene(scene);

        Fade_Manager.FadeOut(scene);

        Time.timeScale = 1;
    }
}
