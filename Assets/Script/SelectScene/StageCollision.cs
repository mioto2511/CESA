using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageCollision : MonoBehaviour
{
    //非同期動作で使用するAsyncOperation
    private AsyncOperation async;

    [Header("次のシーン")] public int scene;

    [Header("再生する動画")] public GameObject mp4;

    [Header("ワールド番号")] public int world_num;

    [Header("ステージ番号")] public int stage_num;

    private bool hit = false;

    //private Shutter shutter;
    //private ChangeScene change_scene;

    private int now_stage_num;

    private bool button_flg = true;

    private ZoomCamera zoom_camera;

    private NumDisplay num_display1;
    private NumDisplay num_display2;

    private int stage_score;

    //スコア用
    private GameObject min;
    private GameObject mid;
    private GameObject max;

    // Start is called before the first frame update
    void Start()
    {
        min = GameObject.Find("min");
        mid = GameObject.Find("mid");
        max = GameObject.Find("max");

        GameObject T = GameObject.Find("Main Camera"); // オブジェクトを探す
        zoom_camera = T.GetComponent<ZoomCamera>();

        GameObject n = GameObject.Find("StageNum");
        num_display1 = n.GetComponent<NumDisplay>();

        GameObject w = GameObject.Find("WorldNum");
        num_display2 = w.GetComponent<NumDisplay>();

        //現在のstage_numを呼び出す
        now_stage_num = PlayerPrefs.GetInt("WORLD"+world_num, 1);

        //現在のstage_scoreを呼び出す
        stage_score = PlayerPrefs.GetInt("WORLD" + world_num + "_STAGE" + stage_num, 0);

        min.GetComponent<Renderer>().material.color = Color.black;
        mid.GetComponent<Renderer>().material.color = Color.black;
        max.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hit)
        {
            if (button_flg)
            {
                if (Input.GetKeyDown("joystick button 0"))
                {
                    button_flg = false;

                    //shutter.shutter_flg = true;

                    //change_scene.NextScene(scene);

                    zoom_camera.zoom_flg = true;

                    zoom_camera.next_scene = scene;
                }
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (now_stage_num >= stage_num)
        {
            hit = true;
            mp4.SetActive(true);
        }

        if (stage_score == 1)
        {
            min.GetComponent<Renderer>().material.color = Color.white;
        }
        else if (stage_score == 2)
        {
            min.GetComponent<Renderer>().material.color = Color.white;
            mid.GetComponent<Renderer>().material.color = Color.white;
        }
        else if (stage_score == 3)
        {
            min.GetComponent<Renderer>().material.color = Color.white;
            mid.GetComponent<Renderer>().material.color = Color.white;
            max.GetComponent<Renderer>().material.color = Color.white;
        }


        //Invoke("DelayMethod", 0.3f);

        
        //数字生成
        num_display1.GenerateNum(stage_num, 0.05f, 0);
        num_display2.GenerateNum(world_num, 0.05f, 0);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        hit = false;

        mp4.SetActive(false);

        //数字削除
        num_display1.DestroyNum();
        num_display2.DestroyNum();

        min.GetComponent<Renderer>().material.color = Color.black;
        mid.GetComponent<Renderer>().material.color = Color.black;
        max.GetComponent<Renderer>().material.color = Color.black;
    }

    //遅延処理
    private void DelayMethod()
    {
        mp4.SetActive(true);
    }


    //シーンロード中に表示するUI画面
    //[SerializeField]
    //private GameObject load_ui;

    //読み込み率を表示するスライダー
    //[SerializeField]
    //private Slider slider;

    //[SerializeField]
    //private string scene_name;
    //public void NextScene()
    //{
    //    //ロード画面ON
    //    load_ui.SetActive(true);

    //    //コルーチンを開始
    //    StartCoroutine("LoadData");
    //}

    //IEnumerator LoadData()
    //{
    //    //シーンの読み込みをする
    //    async = SceneManager.LoadSceneAsync(scene_name);

    //    //読み込みが終わるまで進捗状況をスライダーの値に反映させる
    //    while (!async.isDone)
    //    {
    //        var progressVal = Mathf.Clamp01(async.progress / 0.9f);
    //        slider.value = progressVal;
    //        yield return null;
    //    }
    //}

}
