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

    private Shutter shutter;
    private ChangeScene change_scene;

    private int now_stage_num;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // オブジェクトを探す
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<Shutter>();

        //現在のstage_numを呼び出す
        now_stage_num = PlayerPrefs.GetInt("WORLD"+world_num, 1);

        if (now_stage_num >= stage_num)
        {
            Collider2D my_collider;
            my_collider = GetComponent<Collider2D>();
            my_collider.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                shutter.shutter_flg = true;

                change_scene.NextScene(scene);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hit = true;
        mp4.SetActive(true);
        //Invoke("DelayMethod", 0.3f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        hit = false;

        mp4.SetActive(false);
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
