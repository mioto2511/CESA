using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlg : MonoBehaviour
{
    public bool goal_flg = false;

    private bool button_flg = false;

    private Shutter shutter;
    private ChangeScene change_scene;

    [Header("ゴールからのセレクト")] public int scene = 2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<Shutter>();
    }

    void Update()
    {
        if (goal_flg)
        {
            Invoke("DelayMethod", 0.25f);
        }

        if (button_flg)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                shutter.shutter_flg = true;

                change_scene.NextScene(scene);
            }
        }
    }

    //遅延処理
    private void DelayMethod()
    {
        button_flg = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            goal_flg = true;
        }
    }
}
