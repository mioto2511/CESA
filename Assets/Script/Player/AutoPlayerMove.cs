using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class AutoPlayerMove : MonoBehaviour
{
    private Rigidbody2D rb = null;

    public bool move_flg = true;

    [Header("キャラの速さ")] public float speed;

    //現在の向き
    private bool right_f = true;

    //滑りフラグ
    public bool isSlip = false;

    //スクリプト取得
    [Header("壁接触判定")] public PlayerWallTrigger wall_trigger;
    [Header("床接触判定")] public PlayerGroundTrigger ground_trigger;

    //スケール保存
    private Vector3 tf_s;

    //ゴールへ向かうフラグ
    public bool to_goal = false;

    //ゴール
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Goal 1/DriveGear");

        rb = GetComponent<Rigidbody2D>();

        tf_s = transform.localScale;

        isSlip = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (to_goal)
        {
            Vector3 p_pos = this.transform.position;
            Vector3 t_pos = target.transform.position;

            //ゴールより右なら左向きに
            if(p_pos.x > t_pos.x)
            {
                right_f = false;
            }
            else if(p_pos.x < t_pos.x)
            {
                right_f = true;
            }
        }
        else if (move_flg)
        {
            float xSpeed = 0.0f;

            //壁に衝突したら向き変更
            if (wall_trigger.isOn)
            {
                right_f = !right_f;
            }

            //地面の端で向き変更
            if (ground_trigger.IsGround() == false && isSlip == false)
            {
                right_f = !right_f;
            }

            //右向き
            if (right_f)
            {
                //進行方向
                xSpeed = speed;
                //向き
                transform.localScale = new Vector3(tf_s.x, tf_s.y, 1);
            }
            //左向き
            else
            {
                xSpeed = -speed;
                transform.localScale = new Vector3(-tf_s.x, tf_s.y, 1);
            }

            //代入
            rb.velocity = new Vector2(xSpeed, rb.velocity.y);
        }
        
    }
}
