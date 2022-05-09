using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    [Header("移動経路")] public GameObject[] movePoint;
    [Header("早さ")] public float speed = 1.0f;

    private Rigidbody2D rb = null;
    private int nowPoint = 0;
    private int point_scene = 0;
    private bool PointMax = false;
    private bool PointMin = false;
    private bool RightMove = false;
    private bool LeftMove = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (movePoint != null && movePoint.Length > 0 && rb != null)
        {
            //キャラクターを移動経路の０番目の位置へ
            rb.position = movePoint[0].transform.position;
        }
    }

    // Select_Managerから送られてきたシーン番号を受け取る
    public void Scene(int sceneNo)
    {
        point_scene = sceneNo;
    }

    private void Update()
    {
        //if(Input.GetAxis(""))
        // ゲームパッドの入力処理(今はキーボードの矢印入力になっている)
        if (Input.GetKeyDown(KeyCode.RightArrow) && RightMove == false && LeftMove == false && PointMax == false)
        {
            int nextPoint = nowPoint + 1;

            //移動先が未開放の場合行けないようにする
            if (movePoint[nextPoint].GetComponent<Select_Manager>().NewStageFlg == true)
            {
                RightMove = true;
                //SoundManager.Instance.PlaySE(SESoundData.SE.Select);
                //Debug.Log(nextPoint);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && RightMove == false && LeftMove == false && PointMin == false)
        {
            LeftMove = true;
            //SoundManager.Instance.PlaySE(SESoundData.SE.Select);
            //Debug.Log("L");
        }

        // ステージ選択処理
        if (Input.GetKeyDown("joystick button 0") && RightMove == false && LeftMove == false)
        {
            //SoundManager.Instance.PlaySE(SESoundData.SE.Pick);
            Fade_Manager.FadeOut(point_scene); // Aボタンが押されたらフェードアウトしてシーン遷移する
        }

        // オプションボタンが押されたらワールドセレクトにシーン遷移する
        if(Input.GetKeyDown("joystick button 7"))
        {
            Fade_Manager.FadeOut(10);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 動作処理
        if (movePoint != null && movePoint.Length > 1 && rb != null)
        {
            // 通常進行
            if (RightMove == true)
            {
                int nextPoint = nowPoint + 1;

                // 目標のポイントまでの距離が僅かになるまで移動
                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    // 現在地から次のポイントへのベクトルを計算
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                    // 次のポイントへ移動
                    rb.MovePosition(toVector);
                }
                else
                { // 次のポイントを１つ進める 
                    rb.MovePosition(movePoint[nextPoint].transform.position);
                    ++nowPoint;
                    // 目的地に着いたら動作を止める
                    RightMove = false;
                }
            }
            else if (LeftMove == true)
            {
                int nextPoint = nowPoint - 1;

                // 目標のポイントまでの距離が僅かになるまで移動
                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    // 現在地から次のポイントへのベクトルを計算
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                    // 次のポイントへ移動
                    rb.MovePosition(toVector);
                }
                else
                { // 次のポイントを１つ進める 
                    rb.MovePosition(movePoint[nextPoint].transform.position);
                    --nowPoint;
                    // 目的地に着いたら動作を止める
                    LeftMove = false;
                }
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
}
