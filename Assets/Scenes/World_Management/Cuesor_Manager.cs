using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuesor_Manager : MonoBehaviour
{
    [Header("ワールドマップ")] public GameObject[] movePoint;

    private int nowPoint = 0;
    private bool PointMax = false;
    private bool PointMin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ワールド選択処理
        if (Input.GetKeyDown("joystick button 0"))
        {
            Fade_Manager.FadeOut(movePoint[nowPoint].GetComponent<World_Manager>().World_No); // Aボタンが押されたらフェードアウトしてシーン遷移する
            //Debug.Log(movePoint[nowPoint].GetComponent<World_Manager>().World_No);
        }

        // ゲームパッドの入力処理(今はキーボードの矢印入力になっている)
        if (Input.GetKeyDown(KeyCode.RightArrow)　&& PointMax == false)
        {
            int nextPoint = nowPoint + 1;

            //移動先が未開放の場合行けないようにする
            if (movePoint[nextPoint].GetComponent<World_Manager>().clear == true)
            {
                ++nowPoint;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && PointMin == false)
        {
            --nowPoint;
            //Debug.Log("L");
        }

        // 現在地が配列の最後だった場合
        if (nowPoint + 1 >= movePoint.Length)
        {
            PointMax = true;
            //Debug.Log("max");
        }
        else
        {
            PointMax = false;
        }
        // 現在地が配列の最初だった場合
        if (nowPoint <= 0)
        {
            PointMin = true;
            //Debug.Log("min");
        }
        else
        {
            PointMin = false;
        }
    }
}
