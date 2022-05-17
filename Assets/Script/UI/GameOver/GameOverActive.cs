using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�R���|�[�l���g�̎g�p

public class GameOverActive : MonoBehaviour
{
    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject over_ui;
    [SerializeField]
    private GameObject pause_ui;

    private PlayerFall player_fall;

    private Button b1;

    //PauseActive�̕ϐ�
    private PauseActive pause_active;

    // Start is called before the first frame update
    void Start()
    {
        // �{�^���R���|�[�l���g�̎擾
        b1 = GameObject.Find("/Canvas/GameoverUI/Button4").GetComponent<Button>();

        //GameOver������
        over_ui.SetActive(false);

        GameObject player = GameObject.Find("BoxTrigger");
        player_fall = player.GetComponent<PlayerFall>();�@//�t���Ă���X�N���v�g���擾

        pause_active = pause_ui.GetComponent<PauseActive>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_fall.death_flg)
        {
            player_fall.death_flg = false;

            // ���Ԓ�~
            Time.timeScale = 0;

            //GameOver���o��
            over_ui.SetActive(true);

            pause_active.button_flg = false;

            // �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
            b1.Select();

        }
    }
}
