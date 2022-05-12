using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class PauseActive : MonoBehaviour
{
    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject pauseUI;

    //�|�[�Y�̕\���t���O
	public bool pause_flg = false;

    //RotateStart�̕ϐ����g��
    private RotateStart rotate_start;

    void Start()
    {
        GameObject obj1 = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_start = obj1.GetComponent<RotateStart>();//�t���Ă���X�N���v�g���擾

        //���U���g�w�i������
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (pause_flg)
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                // ���ԍċN
                Time.timeScale = 1;  

                //�|�[�Y������
                pauseUI.SetActive(false);

                //�t���O�܂�
                pause_flg = false;

                //��]�{�^��ON
                rotate_start.botton_flg = true;

                // SE
                SEManager.Instance.Play(SEPath.SE_003);
                BGMManager.Instance.UnPause(BGMPath.BGM_001);
            }
        }
        else
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                // ���Ԓ�~
                Time.timeScale = 0;  

                //�|�[�Y���o��
                pauseUI.SetActive(true);

                //�t���O����
                pause_flg = true;

                //��]�{�^��OFF
                rotate_start.botton_flg = false;

                // SE
                SEManager.Instance.Play(SEPath.SE_003);
                BGMManager.Instance.Pause(BGMPath.BGM_001);
            }
        }
	}
}
