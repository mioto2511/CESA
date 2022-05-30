using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;

public class GoalFlg : MonoBehaviour
{
    public bool goal_flg = false;

    public bool button_flg = false;

    private bool goal_se = false;

    [Header("�S�[������̃Z���N�g")] public int scene = 2;

    [Header("���[���h�ԍ�")] public int world_num = 1;

    [Header("���݂̃X�e�[�W�ԍ�")] public int stage_num = 1;


    //�\��ui
    private GameObject clearUI;

    //Score�̕ϐ�
    private Score score;
    //PauseActive�̕ϐ�
    private PauseActive pause_active;

    private GameObject goal_obj;

    private ClearEffect clear_effect;

    private AutoPlayerMove auto_player;

    public bool display_flg = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject s = GameObject.Find("Room"); // �I�u�W�F�N�g��T��
        score = s.GetComponent<Score>();

        GameObject canvas = GameObject.Find("Canvas"); // �I�u�W�F�N�g��T��
        pause_active = canvas.GetComponent<PauseActive>();

        GameObject p = GameObject.Find("Player");
        auto_player = p.GetComponent<AutoPlayerMove>();

        clearUI = GameObject.Find("ClearUI");

        clearUI.SetActive(false);
    }

    void Update()
    {
        if (goal_flg)
        {
            goal_flg = false;

            score.score_flg = true;

            pause_active.button_flg = false;

            //�G�t�F�N�g
            clear_effect.ef_flg = true;

            goal_se = true;

            Collider2D col = this.GetComponent<Collider2D>();
            col.enabled = false;

            Invoke("DelayMethod", 0.25f);           
        }

        if (display_flg)
        {
            display_flg = false;

            clearUI.SetActive(true);

            Time.timeScale = 0;
        }

        if (goal_se)
        {
            Debug.Log(goal_obj);
            GoalSE();
        }

        if (button_flg)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                // ���ԍċN
                Time.timeScale = 1;

                //shutter.shutter_flg = true;

                //int old_num = PlayerPrefs.GetInt("WORLD" + world_num, 1);
                int old_num  =0;

                switch (world_num)
                {
                    case 1:
                        old_num = SaveManager.save.WORLD[0];
                        break;
                    case 2:
                        old_num = SaveManager.save.WORLD[1];
                        break;
                    case 3:
                        old_num = SaveManager.save.WORLD[2];
                        break;
                    case 4:
                        old_num = SaveManager.save.WORLD[3];
                        break;
                }

                if (old_num < stage_num+1)
                {
                    //
                    //PlayerPrefs.SetInt("WORLD"+world_num, stage_num + 1);
                    switch (world_num) {
                        case 1:
                            Debug.Log("p");
                            SaveManager.save.WORLD[0] = stage_num + 1;
                            SaveManager.Save();
                            break;
                        case 2:
                            Debug.Log("u");
                            SaveManager.save.WORLD[1] = stage_num + 1;
                            SaveManager.Save();
                            break;
                        case 3:
                            SaveManager.save.WORLD[2] = stage_num + 1;
                            SaveManager.Save();
                            break;
                        case 4:
                            SaveManager.save.WORLD[3] = stage_num + 1;
                            SaveManager.Save();
                            break;
                    }

                    
                }

                //switch (world_num)
                //{
                //    case 1:
                //        PlayerPrefs.SetInt("WORLD1", stage_num+1);
                //        break;
                //    case 2:
                //        PlayerPrefs.SetInt("WORLD2", stage_num + 1);
                //        break;
                //    case 3:
                //        PlayerPrefs.SetInt("WORLD3", stage_num + 1);
                //        break;
                //    case 4:
                //        PlayerPrefs.SetInt("WORLD4", stage_num + 1);
                //        break;
                //    case 5:
                //        PlayerPrefs.SetInt("WORLD5", stage_num + 1);
                //        break;
                //    case 6:
                //        PlayerPrefs.SetInt("WORLD6", stage_num + 1);
                //        break;
                //}

                //�X�e�[�W�ԍ��̕ۑ�
                //PlayerPrefs.SetInt("OLDSTAGE", stage_num);

                SaveManager.save.OLD_STAGE = stage_num;
                SaveManager.Save();

                //PlayerPrefs.Save();

                //change_scene.NextScene(scene);
                Fade_Manager.FadeOut(scene);
            }
        }
    }

    //�x������
    private void DelayMethod()
    {
        //button_flg = true;

        auto_player.move_flg = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            goal_flg = true;

            Time.timeScale = 1;

            //�S�[���I�u�W�F�N�g�擾
            goal_obj = collision.transform.GetChild(0).gameObject;
            clear_effect = goal_obj.GetComponent<ClearEffect>();
        }
    }

    private void GoalSE()
    {
        Debug.Log("ClearSE");
        // BGM�t�F�[�h�A�E�g��N���ASE��炷
        BGMManager.Instance.Stop();
        SEManager.Instance.Stop();
        
       goal_se = false;
    }
}
