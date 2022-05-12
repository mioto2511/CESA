using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;

public class GoalFlg : MonoBehaviour
{
    public bool goal_flg = false;

    private bool button_flg = false;

    private bool goal_se = false;

    private Shutter shutter;
    private ChangeScene change_scene;

    [Header("ゴールからのセレクト")] public int scene = 2;

    [Header("ワールド番号")] public int world_num = 1;

    [Header("次のステージ番号")] public int stage_num = 2;

    /////////////////
    [SerializeField]
    private GameObject pauseUI;
    /////////////////

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<Shutter>();

        /////////////////
        pauseUI.SetActive(false);
        /////////////////
    }

    void Update()
    {
        if (goal_flg)
        {
            goal_se = true;
            goal_flg = false;

            Invoke("DelayMethod", 0.25f);           
        }

        if (goal_se)
        {
            GoalSE();
            
        }

        if (button_flg)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                // 時間再起
                Time.timeScale = 1;

                shutter.shutter_flg = true;

                switch (world_num)
                {
                    case 1:
                        PlayerPrefs.SetInt("STAGE1", stage_num);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("STAGE2", stage_num);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("STAGE3", stage_num);
                        break;
                    case 4:
                        PlayerPrefs.SetInt("STAGE4", stage_num);
                        break;
                    case 5:
                        PlayerPrefs.SetInt("STAGE5", stage_num);
                        break;
                    case 6:
                        PlayerPrefs.SetInt("STAGE6", stage_num);
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

    //遅延処理
    private void DelayMethod()
    {
        button_flg = true;

        // 時間停止
        Time.timeScale = 0;

        /////////////////
        pauseUI.SetActive(true);
        /////////////////
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            goal_flg = true;
        }
    }

    private void GoalSE()
    {
        Debug.Log("ClearSE");
        // BGMフェードアウト後クリアSEを鳴らす
        BGMManager.Instance.Stop(BGMPath.BGM_001);
        SEManager.Instance.Play(SEPath.SE_010);
       goal_se = false;
    }
}
