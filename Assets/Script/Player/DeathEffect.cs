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

    //�J���[
    private SpriteRenderer mesh;

    private void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas"); //�I�u�W�F�N�g��T��
        gameover_active = canvas.GetComponent<GameOverActive>();

        GameObject p = GameObject.Find("BoxTrigger");
        player_fall = p.GetComponent<PlayerFall>();�@//�t���Ă���X�N���v�g���擾

        //�v���C���[�����X�ɓ��������鏀��
        player = GameObject.Find("Player");
        mesh = player.GetComponent<SpriteRenderer>();
        mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 0);

        //���悪�I��������̏���
        video_player.loopPointReached += FinishPlayingVideo;

        //���O���[�h
        video_player.Prepare();

        //������
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 2);
    }

    //Update is called once per frame
    void Update()
    {
        //���S
        if (player_fall.death_flg)
        {
            //����Đ�
            video_player.started += OnMovieStarted;
            video_player.Play();

            //������
            StartCoroutine("Transparent");

            player_fall.death_flg = false;
        }
    }

    void OnMovieStarted(VideoPlayer vp)
    {
        //���̉�
        Material mat = this.gameObject.GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Near", 0.63f);
    }

    public void FinishPlayingVideo(VideoPlayer vp)
    {
        //���U���g�\��
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
