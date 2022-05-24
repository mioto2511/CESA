using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DeathEffect : MonoBehaviour
{
    public VideoPlayer video_player;

    private PlayerFall player_fall;

    private GameOverActive gameover_active;

    private bool start_flg = true;

    private int count = 0;

    private GameObject player;

    //�J���[
    private SpriteRenderer mesh;

    private void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas"); //�I�u�W�F�N�g��T��
        gameover_active = canvas.GetComponent<GameOverActive>();

        GameObject p = GameObject.Find("BoxTrigger");
        player_fall = p.GetComponent<PlayerFall>();�@//�t���Ă���X�N���v�g���擾

        player = GameObject.Find("Player");
        mesh = player.GetComponent<SpriteRenderer>();
        mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 0);

        video_player.loopPointReached += FinishPlayingVideo;

        //video_player.Pause();
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
    }

    //Update is called once per frame
    void Update()
    {
        if (start_flg)
        {
            count++;

            if (count >= 7)
            {
                start_flg = false;

                video_player.Pause();
            }
        }

        if (player_fall.death_flg)
        {
            video_player.Play();

            StartCoroutine("Transparent");

            player_fall.death_flg = false;
        }
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
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
