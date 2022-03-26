using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActive : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUI;

	private bool pause_flg = false;

    // Start is called before the first frame update
    void Start()
    {
        //リザルト背景を消す
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pause_flg)
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                Time.timeScale = 1;  // 時間停止
                                     //リザルト背景を消す
                pauseUI.SetActive(false);

                pause_flg = false;
            }
        }
        else
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                Time.timeScale = 0;  // 時間停止
                                     //リザルト背景を消す
                pauseUI.SetActive(true);

                pause_flg = true;
            }
        }
	}
}
