using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUI;

    private PauseActive pause_active;

    void Start()
    {
        GameObject obj1 = GameObject.Find("Canvas"); //オブジェクトを探す
        pause_active = obj1.GetComponent<PauseActive>();//付いているスクリプトを取得

        //リザルト背景を消す
        pauseUI.SetActive(false);
    }

    public void OnClickStartButton()
    {
        Time.timeScale = 1;  // 時間再開

        //ポーズのフラグ
        pause_active.pause_flg = false;

        //リザルト背景を消す
        pauseUI.SetActive(false);
    }
}
