using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject star;
    public GameObject score_back;
    public int score;
    private int count = 0;

    //private bool flg = false;

    //GoalFlgの変数を使用
    private GoalFlg goal_flg;

    // Start is called before the first frame update
    void Start()
    {
        //リザルト背景を消す
        score_back.SetActive(false);

        GameObject goal = GameObject.Find("Player"); //オブジェクトを探す
        goal_flg = goal.GetComponent<GoalFlg>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateRoom.instance.room_hit == true)
        {
            count++;
        }

        

        if (GameObject.Find("Room").transform.childCount >= 3)
        {
            if (goal_flg.goal_flg == true)
            {
                if (count <= score)
                {
                    star.SetActive(true);
                    score_back.SetActive(true);

                    //Debug.Log("a");
                }
            }
        }
    }
}
