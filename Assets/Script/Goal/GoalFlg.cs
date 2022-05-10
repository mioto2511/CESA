using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlg : MonoBehaviour
{
    public bool goal_flg = false;

    private bool button_flg = false;

    private Shutter shutter;
    private ChangeScene change_scene;

    [Header("�S�[������̃Z���N�g")] public int scene = 2;

    [Header("���[���h�ԍ�")] public int world_num = 1;

    [Header("���݂̃X�e�[�W�ԍ�")] public int stage_num = 1;

    //�\��ui
    [SerializeField]
    private GameObject clearUI;

    //Score�̕ϐ�
    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // �I�u�W�F�N�g��T��
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<Shutter>();

        GameObject s = GameObject.Find("Room"); // �I�u�W�F�N�g��T��
        score = s.GetComponent<Score>();

        clearUI.SetActive(false);
    }

    void Update()
    {
        if (goal_flg)
        {
            goal_flg = false;

            score.score_flg = true;

            Invoke("DelayMethod", 0.25f);           
        }

        if (button_flg)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                // ���ԍċN
                Time.timeScale = 1;

                shutter.shutter_flg = true;

                switch (world_num)
                {
                    case 1:
                        PlayerPrefs.SetInt("WORLD1", stage_num+1);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("WORLD2", stage_num + 1);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("WORLD3", stage_num + 1);
                        break;
                    case 4:
                        PlayerPrefs.SetInt("WORLD4", stage_num + 1);
                        break;
                    case 5:
                        PlayerPrefs.SetInt("WORLD5", stage_num + 1);
                        break;
                    case 6:
                        PlayerPrefs.SetInt("WORLD6", stage_num + 1);
                        break;
                }

                if (stage_num == 6)
                {
                    PlayerPrefs.SetInt("WORLD", world_num+1);
                }

                PlayerPrefs.Save();

                change_scene.NextScene(scene);
            }
        }
    }

    //�x������
    private void DelayMethod()
    {
        button_flg = true;

        // ���Ԓ�~
        Time.timeScale = 0;

        clearUI.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            goal_flg = true;
        }
    }
}
