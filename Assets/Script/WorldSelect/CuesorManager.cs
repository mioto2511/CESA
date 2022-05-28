using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
using UnityEngine.SceneManagement;

public class CuesorManager : MonoBehaviour
{
    [Header("ワールドマップ")] public GameObject[] movePoint;

    [Header("拡大")] public float up_size = 0.19f;

    private GameObject kari;

    private int nowPoint = 0;
    private int oldPoint = 0;
    private bool PointMax = false;
    private bool PointMin = false;

    private OpenShutter shutter;
    private ChangeScene change_scene;

    //デットゾーン
    private float deadzone = 0.2f;

    private bool stick_flg = true;

    private bool button_flg = true;

    public LoopFrame loop_frame;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<OpenShutter>();

        kari = GameObject.Find("Fuchi");
        kari.transform.localScale = new Vector3(up_size, up_size, 1);
        movePoint[nowPoint].transform.localScale = new Vector3(up_size, up_size, 1);

        Vector3 pos = movePoint[nowPoint].transform.position;
        kari.transform.position = new Vector3(pos.x, pos.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (button_flg)
        {
            // ワールド選択処理
            if (Input.GetKeyDown("joystick button 0"))
            {
               // SEManager.Instance.Play(SEPath.SE_005);

                button_flg = false;

                shutter.shutter_flg = true;

                //動画ループ停止
                loop_frame.loop_flg = false;

                change_scene.NextScene(movePoint[nowPoint].GetComponent<WorldManager>().World_No);

                //ステージ番号の保存
                PlayerPrefs.SetInt("OLDSTAGE", 1);
                PlayerPrefs.Save();
                //SceneManager.LoadScene(movePoint[nowPoint].GetComponent<WorldManager>().World_No);

                //Fade_Manager.FadeOut(movePoint[nowPoint].GetComponent<WorldManager>().World_No); // Aボタンが押されたらフェードアウトしてシーン遷移する
                //Debug.Log(movePoint[nowPoint].GetComponent<World_Manager>().World_No);          
            }
        }
        

        float lsh = Input.GetAxis("L_Stick_H");//横軸
        //Debug.Log(nowPoint);
        if (stick_flg)
        {
            // ゲームパッドの入力処理(今はキーボードの矢印入力になっている)
            if (lsh > deadzone && PointMax == false)
            {
                stick_flg = false;

                int nextPoint = nowPoint + 1;

                //移動先が開放の場合行けるようにする
                if (movePoint[nextPoint].GetComponent<WorldManager>().clear == true)
                {
                    //SEManager.Instance.Play(SEPath.SE_004);
                    ++nowPoint;

                    //カーソル設置
                    Vector3 pos = movePoint[nowPoint].transform.position;
                    kari.transform.position = new Vector3(pos.x, pos.y, 0);

                    movePoint[nowPoint].transform.localScale = new Vector3(up_size, up_size, 1);
                    movePoint[oldPoint].transform.localScale = new Vector3(0.18f, 0.18f, 1);

                    oldPoint = nowPoint;
                }
                //遅らせて処理するもの
                Invoke("DelayMethod", 0.5f);
            }
            if (lsh < -deadzone && PointMin == false)
            {
                stick_flg = false;

                //SoundManager.Instance.PlaySE(SESoundData.SE.Select);
                --nowPoint;

                //カーソル設置
                Vector3 pos = movePoint[nowPoint].transform.position;
                kari.transform.position = new Vector3(pos.x, pos.y, 0);

                movePoint[nowPoint].transform.localScale = new Vector3(up_size, up_size, 1);
                movePoint[oldPoint].transform.localScale = new Vector3(0.18f,0.18f,1);

                oldPoint = nowPoint;

                //遅らせて処理するもの
                Invoke("DelayMethod", 0.5f);
            }
        }
        

        // 現在地が配列の最後だった場合
        if (nowPoint + 1 >= movePoint.Length)
        {
            PointMax = true;
            //Debug.Log("max");
        }
        else
        {
            PointMax = false;
        }
        // 現在地が配列の最初だった場合
        if (nowPoint <= 0)
        {
            PointMin = true;
            //Debug.Log("min");
        }
        else
        {
            PointMin = false;
        }
    }

    //遅延処理
    private void DelayMethod()
    {
        stick_flg = true;
    }
}
