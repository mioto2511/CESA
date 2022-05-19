using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;

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
            SEManager.Instance.Play(SEPath.SE_009);
            //遅らせて処理するもの
            Invoke("DelayMethod", 0.5f);
        }
    }

    //遅延処理
    private void DelayMethod()
    {
        SceneManager.LoadScene(next_scene);
    }
}
