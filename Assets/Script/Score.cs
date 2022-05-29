using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class Score : MonoBehaviour
{
    // UI
    //private GameObject mid_obj;
    //private GameObject max_obj;

    [Header("現在のスコア")] public int score;

    [Header("星2のスコア")] public int mid_score;

    [Header("星3のスコア")] public int max_score;

    [Header("ワールドの番号")] public int world_num;

    [Header("ステージの番号")] public int stage_num;

    [Header("ワールドの解放スコア")] public int release_score;

    public GameObject one_start;
    public GameObject one_loop;
    public GameObject two_start;
    public GameObject two_loop;
    public GameObject three_start;
    public GameObject three_loop;

    private int stage_score;

    public int star;

    public bool score_flg;

    private int world_score = 0;

    public static Score instance;

    private NumDisplay num_display1;
    private NumDisplay num_display2;

    private GoalFlg goal_flg;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //mid_obj = GameObject.Find("mid");
        //max_obj = GameObject.Find("max");
    }

    // Start is called before the first frame update
    void Start()
    {
        //現在のworld_scoreを呼び出す
        world_score = PlayerPrefs.GetInt("WORLD_SCORE", 0);

        //現在のstage_scoreを呼び出す
        stage_score = PlayerPrefs.GetInt("WORLD"+world_num+"_STAGE"+stage_num, 0);

        GameObject g = GameObject.Find("GoalTrigger");
        goal_flg = g.GetComponent<GoalFlg>();

        GameObject n = GameObject.Find("NowNum");
        num_display1 = n.GetComponent<NumDisplay>();

        GameObject m = GameObject.Find("MaxNum");
        num_display2 = m.GetComponent<NumDisplay>();

        num_display2.GenerateUINum(max_score, 0.03f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //スコア加算用
        int now_socre = 0;

        // タグが同じオブジェクトを全て取得する
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ActiveBox");

        //ActiveBoxの数だけスコアに反映
        foreach (GameObject gameObj in gameObjects)
        {
            now_socre++;
        }

        if(score != now_socre)
        {
            //現在のスコアを代入
            score = now_socre;

            num_display1.DestroyNum();
            num_display1.GenerateUINum(score,0.03f,0);
        }
 
        //テキスト表示
        //text.text = score + "/" + max_score;

        //クリア時のスコア表示
        if (score_flg)
        {
            score_flg = false;

            //左上のスコア表示OFF
            //text_obj.SetActive(false);

            //はじめは星3
            //star = 3;

            if(score >= max_score)
            {
                three_start.SetActive(true);
                three_loop.SetActive(true);
                star = 3;
            }
            else if (score >= mid_score)
            {
                two_start.SetActive(true);
                two_loop.SetActive(true);
                star = 2;
            }
            else
            {
                one_start.SetActive(true);
                one_loop.SetActive(true);
                star = 1;
            }

            //スコア更新
            if (star > stage_score)
            {
                world_score += (star - stage_score);

                stage_score = star;
            }

            //ワールド解放
            if (world_score >= release_score)
            {
                goal_flg.scene = 1;
            }

            //セーブ
            PlayerPrefs.SetInt("WORLD" + world_num + "_STAGE" + stage_num, stage_score);
            PlayerPrefs.SetInt("WORLD_SCORE", world_score);
            PlayerPrefs.Save();
        }
    }
}
