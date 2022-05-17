using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用
using KanKikuchi.AudioManager;

public class GameOverActive : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject over_ui;

    private PlayerFall player_fall;

    private Button b1;

    //Accelerationの変数を使う
    private Acceleration acceleration;

    // Start is called before the first frame update
    void Start()
    {
        // ボタンコンポーネントの取得
        b1 = GameObject.Find("/Canvas/GameoverUI/Button4").GetComponent<Button>();

        //リザルト背景を消す
        over_ui.SetActive(false);

        GameObject player = GameObject.Find("BoxTrigger");
        player_fall = player.GetComponent<PlayerFall>();　//付いているスクリプトを取得

        GameObject obj2 = GameObject.Find("Player"); //オブジェクトを探す
        acceleration = obj2.GetComponent<Acceleration>();//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (player_fall.death_flg)
        {
            player_fall.death_flg = false;

            // 時間停止
            Time.timeScale = 0;

            //加速不可能にする
            acceleration.button_flg = false;

            //ポーズを出す
            over_ui.SetActive(true);

            BGMManager.Instance.Stop();

            // 最初に選択状態にしたいボタンの設定
            b1.Select();

        }
    }
}
