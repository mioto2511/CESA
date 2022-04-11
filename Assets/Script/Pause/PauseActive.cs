using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActive : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUI;

    //ポーズの表示フラグ
	private bool pause_flg = false;

    void Start()
    {
        //リザルト背景を消す
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (pause_flg)
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                // 時間再起
                Time.timeScale = 1;  

                //ポーズを消す
                pauseUI.SetActive(false);

                //フラグ折る
                pause_flg = false;
            }
        }
        else
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                // 時間停止
                Time.timeScale = 0;  

                //ポーズを出す
                pauseUI.SetActive(true);

                //フラグ立つ
                pause_flg = true;
            }
        }
	}
}
