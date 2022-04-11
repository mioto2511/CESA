using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActive : MonoBehaviour
{
    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject pauseUI;

    //�|�[�Y�̕\���t���O
	private bool pause_flg = false;

    void Start()
    {
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
            }
        }
	}
}
