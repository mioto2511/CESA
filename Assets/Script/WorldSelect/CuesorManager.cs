using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class CuesorManager : MonoBehaviour
{
    [Header("ワールドマップ")] public GameObject[] movePoint;

    public GameObject kari;

    private int nowPoint = 0;
    private bool PointMax = false;
    private bool PointMin = false;

    private Shutter shutter;
    private ChangeScene change_scene;

    //デットゾーン
    private float deadzone = 0.2f;

    private bool stick_flg = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<Shutter>();

        kari = GameObject.Find("Circle");

        Vector3 pos = movePoint[nowPoint].transform.position;
        kari.transform.position = new Vector3(pos.x, pos.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // ワールド選択処理
        if (Input.GetKeyDown("joystick button 0"))
        {
            SEManager.Instance.Play(SEPath.SE_005);

            shutter.shutter_flg = true;

            change_scene.NextScene(movePoint[nowPoint].GetComponent<WorldManager>().World_No);

            //Fade_Manager.FadeOut(movePoint[nowPoint].GetComponent<WorldManager>().World_No); // Aボタンが押されたらフェードアウトしてシーン遷移する
            //Debug.Log(movePoint[nowPoint].GetComponent<World_Manager>().World_No);          
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

                //移動先が未開放の場合行けないようにする
                if (movePoint[nextPoint].GetComponent<WorldManager>().clear == true)
                {
                    //SEManager.Instance.Play(SEPath.SE_004);
                    ++nowPoint;
                    Vector3 pos = movePoint[nowPoint].transform.position;
                    kari.transform.position = new Vector3(pos.x, pos.y, 0);
                }
                //遅らせて処理するもの
                Invoke("DelayMethod", 0.5f);
            }
            if (lsh < -deadzone && PointMin == false)
            {
                stick_flg = false;

                //SoundManager.Instance.PlaySE(SESoundData.SE.Select);
                --nowPoint;
                Vector3 pos = movePoint[nowPoint].transform.position;
                kari.transform.position = new Vector3(pos.x, pos.y, 0);
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
