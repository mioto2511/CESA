using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用

    [Header("次のシーン")] public int next_scene;

    // Use this for initialization
    void Start()
    {
        step_time = 0.0f;   // 経過時間初期化
    }

    public void NextScene(int next)
    {
        next_scene = next;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shutter"))
        {
            Fade_Manager.FadeOut(next_scene); // フェードイン開始、番号でフェード後のsceneを指定
        }
       
    }
}
