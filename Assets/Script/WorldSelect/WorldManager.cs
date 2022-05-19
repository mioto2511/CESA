using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    [Header("フレームインするまでの時間")] public float in_time = 0.01f;

    [Header("着地までの時間")] public float stand_time = 0.005f;

    [Header("ワールド開放")] public bool clear = false;

    [Header("シーンビルドの番号")] public int World_No = 0;

    [Header("ワールドの番号")] public int world_num;

    [Header("ワールド解放スコア")] public int conditions_score;

    [Header("ワールド最大スコア")] public int max_score;

    public Text text;

    //現在のワールドのスコア
    private int world_score;

    //子
    private GameObject chain;

    private Vector3 pos;
    private Vector3 scale;

    void Start()
    {
        //現在のworld_numを呼び出す
        world_score = PlayerPrefs.GetInt("WORLD" + world_num + "_SCORE", 0);

        //子を取得
        chain = this.transform.GetChild(0).gameObject;

        //現在のワールド番号が満たしていたら解放
        if (world_score >= conditions_score)
        {
            clear = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();

        //テキスト表示
        text.text = world_score + "/" + max_score;

        

        
    }

    private void FixedUpdate()
    {
        pos = this.transform.position;
        scale = this.transform.localScale;

        if (pos.z <= 0)
        {
            pos.z += in_time;
            //pos.y -= 0.01f;

            this.transform.position = pos;
            //this.transform.localScale = scale;
        }

        if (scale.x > 0.3f)
        {
            this.transform.localScale -= new Vector3(stand_time, stand_time, 0);
        }
    }

    private void ColorChange()
    {
        if (clear == true)
        {
            GetComponent<Renderer>().material.color = Color.white;
            //鎖OFF
            chain.SetActive(false);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color32(99, 99, 99,255);
        }
    }
}
