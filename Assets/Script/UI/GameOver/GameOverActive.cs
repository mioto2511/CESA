using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�R���|�[�l���g�̎g�p
using KanKikuchi.AudioManager;

public class GameOverActive : MonoBehaviour
{
    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject over_ui;

    private PlayerFall player_fall;

    private Button b1;

    //Acceleration�̕ϐ����g��
    private Acceleration acceleration;

    // Start is called before the first frame update
    void Start()
    {
        // �{�^���R���|�[�l���g�̎擾
        b1 = GameObject.Find("/Canvas/GameoverUI/Button4").GetComponent<Button>();

        //���U���g�w�i������
        over_ui.SetActive(false);

        GameObject player = GameObject.Find("BoxTrigger");
        player_fall = player.GetComponent<PlayerFall>();�@//�t���Ă���X�N���v�g���擾

        GameObject obj2 = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        acceleration = obj2.GetComponent<Acceleration>();//�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (player_fall.death_flg)
        {
            player_fall.death_flg = false;

            // ���Ԓ�~
            Time.timeScale = 0;

            //�����s�\�ɂ���
            acceleration.button_flg = false;

            //�|�[�Y���o��
            over_ui.SetActive(true);

            BGMManager.Instance.Stop();

            // �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
            b1.Select();

        }
    }
}
