using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUI;

    private PauseActive pause_active;

    //RotateStartの変数を使う
    private RotateStart rotate_start;
    //Accelerationの変数を使う
    private Acceleration acceleration;

    void Start()
    {
        GameObject obj3 = GameObject.Find("Room"); //オブジェクトを探す
        rotate_start = obj3.GetComponent<RotateStart>();//付いているスクリプトを取得

        GameObject obj2 = GameObject.Find("Player"); //オブジェクトを探す
        acceleration = obj2.GetComponent<Acceleration>();//付いているスクリプトを取得

        GameObject obj1 = GameObject.Find("Canvas"); //オブジェクトを探す
        pause_active = obj1.GetComponent<PauseActive>();//付いているスクリプトを取得

        //リザルト背景を消す
        //pauseUI.SetActive(false);
    }

    public void OnClickStartButton()
    {
        Time.timeScale = 1;  // 時間再開

        //ポーズのフラグ
        pause_active.pause_flg = false;

        //遅らせて処理するもの
        Invoke("DelayMethod", 0.5f);

        

        //背景を消す
        pauseUI.SetActive(false);
    }

    //遅延処理
    private void DelayMethod()
    {
        //加速可能にする
        acceleration.button_flg = true;

        //回転ボタンON
        rotate_start.botton_flg = true;
    }
}
