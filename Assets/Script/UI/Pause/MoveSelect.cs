using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelect : MonoBehaviour
{
    //private Shutter shutter;
    //private ChangeScene change_scene;

    [Header("�|�[�Y����̃Z���N�g")] public int scene = 2;

    private GoalFlg goal_flg;


    void Start()
    {
        //GameObject T = GameObject.Find("ShutterTrigger"); // �I�u�W�F�N�g��T��
        //change_scene = T.GetComponent<ChangeScene>();
        //shutter = T.GetComponent<Shutter>();

        GameObject g = GameObject.Find("GoalTrigger");
        goal_flg = g.GetComponent<GoalFlg>();
    }

    public void OnClickStartButton()
    {
        //shutter.shutter_flg = true;

        //change_scene.NextScene(scene);

        //�X�e�[�W�ԍ��̕ۑ�
        PlayerPrefs.SetInt("OLDSTAGE", goal_flg.stage_num);

        PlayerPrefs.Save();

        Fade_Manager.FadeOut(scene);

        Time.timeScale = 1;
    }
}
