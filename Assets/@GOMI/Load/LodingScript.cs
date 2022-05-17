using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingScript : MonoBehaviour
{
    //非同期動作で使用するAsyncOperation
    private AsyncOperation async;

    //シーンロード中に表示するUI画面
    [SerializeField]
    private GameObject load_ui;

    //読み込み率を表示するスライダー
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private string scene_name;

    public void NextScene()
    {
        //ロード画面ON
        load_ui.SetActive(true);

        //コルーチンを開始
        StartCoroutine("LoadData");
    }

    IEnumerator LoadData()
    {
        //シーンの読み込みをする
        async = SceneManager.LoadSceneAsync(scene_name);

        //読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }
}
