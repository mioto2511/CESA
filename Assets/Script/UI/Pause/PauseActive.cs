using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActive : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUI;

    //ポーズの表示フラグ
	public bool pause_flg = false;

    //RotateStartの変数を使う
    private RotateStart rotate_start;

    void Start()
    {
        GameObject obj1 = GameObject.Find("Room"); //オブジェクトを探す
        rotate_start = obj1.GetComponent<RotateStart>();//付いているスクリプトを取得

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

                //回転ボタンON
                rotate_start.botton_flg = true;
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

                //回転ボタンOFF
                rotate_start.botton_flg = false;
            }
        }
	}
}
