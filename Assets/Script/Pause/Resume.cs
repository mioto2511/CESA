using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject pauseUI;

    public void OnClickStartButton()
    {
        Time.timeScale = 1;  // ���Ԓ�~
                             //���U���g�w�i������
        pauseUI.SetActive(false);
    }
}
