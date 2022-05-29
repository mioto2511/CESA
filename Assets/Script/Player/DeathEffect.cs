using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DeathEffect : MonoBehaviour
{
    public VideoPlayer video_player;

    private PlayerFall player_fall;

    private GameOverActive gameover_active;

    private GameObject player;

    //カラー
    private SpriteRenderer mesh;

    private void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas"); //オブジェクトを探す
        gameover_active = canvas.GetComponent<GameOverActive>();

        GameObject p = GameObject.Find("BoxTrigger");
        player_fall = p.GetComponent<PlayerFall>();　//付いているスクリプトを取得

        //プレイヤーを徐々に透明化する準備
        player = GameObject.Find("Player");
        mesh = player.GetComponent<SpriteRenderer>();
        mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 0);

        //動画が終わった時の処理
        video_player.loopPointReached += FinishPlayingVideo;

        //事前ロード
        video_player.Prepare();

        //透明化
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 2);
    }

    //Update is called once per frame
    void Update()
    {
        //死亡
        if (player_fall.death_flg)
        {
            //動画再生
            video_player.started += OnMovieStarted;
            video_player.Play();

            //透明化
            StartCoroutine("Transparent");

            player_fall.death_flg = false;
        }
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //実体化
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 0.63f);
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        //リザルト表示
        gameover_active.result_flg = true;
    }

    IEnumerator Transparent()
    {
        for (int i = 0; i < 255; i++)
        {
            mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 2);
            yield return new WaitForSeconds(0.0f);
        }
    }
}
