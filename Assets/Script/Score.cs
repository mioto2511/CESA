using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // UI
    public Text text;
    public GameObject text_obj;
    public GameObject mid_obj;
    public GameObject max_obj;

    [Header("現在のスコア")] public int score;

    [Header("星2のスコア")] public int mid_score;

    [Header("星3のスコア")] public int max_score;

    [Header("ワールドの番号")] public int world_num;
    [Header("ステージの番号")] public int stage_num;

    private int stage_score;

    private int star;

    public bool score_flg;

    private int world_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //現在のstage_numを呼び出す
        world_score = PlayerPrefs.GetInt("WORLD" + world_num + "_SCORE", 0);

        stage_score = PlayerPrefs.GetInt("WORLD"+world_num+"_STAGE"+stage_num, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //テキスト表示
        text.text = score + "/" + max_score;

        if (score_flg)
        {
            score_flg = false;

            text_obj.SetActive(false);

            star = 3;

            if (score < max_score)
            {
                max_obj.SetActive(false);
                star -= 1;
            }
            if (score < mid_score)
            {
                mid_obj.SetActive(false);
                star -= 1;
            }
            

            //スコア更新
            if(star > stage_score)
            {
                world_score += (star - stage_score);

                stage_score = star;
            }

            PlayerPrefs.SetInt("WORLD" + world_num + "_STAGE" + stage_num, stage_score);
            PlayerPrefs.SetInt("WORLD" + world_num + "_SCORE", world_score);
            PlayerPrefs.Save();
        }
    }
}
