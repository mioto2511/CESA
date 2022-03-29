using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用

    // Use this for initialization
    void Start()
    {
        step_time = 0.0f;   // 経過時間初期化
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shutter"))
        {
            Fade_Manager.FadeOut(1); // フェードイン開始、番号でフェード後のsceneを指定
        }
       
    }
}
