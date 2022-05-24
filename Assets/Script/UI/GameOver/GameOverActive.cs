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

    private Button b1;

    public bool result_flg = false;

    //Acceleration�̕ϐ����g��
    private Acceleration acceleration;
    //PauseActive�̕ϐ�
    private PauseActive pause_active;

    // Start is called before the first frame update
    void Start()
    {
        // �{�^���R���|�[�l���g�̎擾
        b1 = GameObject.Find("/Canvas/GameoverUI/Button4").GetComponent<Button>();

        //���U���g�w�i������
        over_ui.SetActive(false);

        GameObject obj2 = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        acceleration = obj2.GetComponent<Acceleration>();//�t���Ă���X�N���v�g���擾

        //GameObject canvas = GameObject.Find("Canvas"); //�I�u�W�F�N�g��T��
        pause_active = this.GetComponent<PauseActive>();
    }

    // Update is called once per frame
    void Update()
    {
        if (result_flg)
        {
            result_flg = false;

            // ���Ԓ�~
            Time.timeScale = 0;

            //�����s�\�ɂ���
            acceleration.button_flg = false;

            //�o��
            over_ui.SetActive(true);

            //�|�[�Y�ł��Ȃ�
            pause_active.button_flg = false;

            BGMManager.Instance.Stop();

            // �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
            b1.Select();

        }
    }
}
