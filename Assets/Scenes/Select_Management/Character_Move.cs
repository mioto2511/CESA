using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    [Header("移動経路")] public GameObject[] movePoint;
    [Header("早さ")] public float speed = 1.0f;

    private Rigidbody2D rb = null;
    private int nowPoint = 0;
    private bool returnPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        if (movePoint != null && movePoint.Length > 0 && rb != null)
        {
            //キャラクターを移動経路の０番目の位置へ
            rb.position = movePoint[0].transform.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 通常移動
        if (!returnPoint)
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
            { //次のポイントを１つ進める 
                rb.MovePosition(movePoint[nextPoint].transform.position);
                ++nowPoint;

                // 現在地が配列の最後だった場合
                if (nowPoint + 1 >= movePoint.Length)
                {
                    returnPoint = true;
                }
            }
        }
        else
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
                --nowPoint;

                // 現在地が配列の最初だった場合
                if (nowPoint <=0)
                {
                    returnPoint = false;
                }
            }
        }
        
    }
}
