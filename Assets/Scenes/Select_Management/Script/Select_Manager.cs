using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Manager : MonoBehaviour
{
    [Header("シーンビルドの番号")] public int stage_No = 0;
    [Header("ステージクリア")] public bool ClearFlg = false;
    [Header("新しいステージ")] public bool NewStageFlg = false;

    // プレイヤーの位置のポイントのシーン番号をCharacter_Moveに送る
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Character_Move>())
        {
            other.gameObject.GetComponent<Character_Move>().Scene(stage_No);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ClearFlg == true)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            NewStageFlg = false;
        }

        if (NewStageFlg == true)
        {
            GetComponent<Renderer>().material.color = Color.red;
            ClearFlg = false;
        }
    }
}