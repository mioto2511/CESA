using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject pauseUI;

    private PauseActive pause_active;

    void Start()
    {
        GameObject obj1 = GameObject.Find("Canvas"); //�I�u�W�F�N�g��T��
        pause_active = obj1.GetComponent<PauseActive>();//�t���Ă���X�N���v�g���擾

        //���U���g�w�i������
        pauseUI.SetActive(false);
    }

    public void OnClickStartButton()
    {
        Time.timeScale = 1;  // ���ԍĊJ

        //�|�[�Y�̃t���O
        pause_active.pause_flg = false;

        //���U���g�w�i������
        pauseUI.SetActive(false);
    }
}
