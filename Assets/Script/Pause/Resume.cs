using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUI;

    public void OnClickStartButton()
    {
        Time.timeScale = 1;  // 時間停止
                             //リザルト背景を消す
        pauseUI.SetActive(false);
    }
}
