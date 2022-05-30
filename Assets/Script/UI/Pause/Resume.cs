using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject pauseUI;

    private PauseActive pause_active;

    //RotateStart�̕ϐ����g��
    private RotateStart rotate_start;
    //Acceleration�̕ϐ����g��
    private Acceleration acceleration;

    void Start()
    {
        GameObject obj3 = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
        rotate_start = obj3.GetComponent<RotateStart>();//�t���Ă���X�N���v�g���擾

        GameObject obj2 = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        acceleration = obj2.GetComponent<Acceleration>();//�t���Ă���X�N���v�g���擾

        GameObject obj1 = GameObject.Find("Canvas"); //�I�u�W�F�N�g��T��
        pause_active = obj1.GetComponent<PauseActive>();//�t���Ă���X�N���v�g���擾

        //���U���g�w�i������
        //pauseUI.SetActive(false);
    }

    public void OnClickStartButton()
    {
        Time.timeScale = 1;  // ���ԍĊJ

        //�|�[�Y�̃t���O
        pause_active.pause_flg = false;

        //�x�点�ď����������
        Invoke("DelayMethod", 0.5f);

        

        //�w�i������
        pauseUI.SetActive(false);
    }

    //�x������
    private void DelayMethod()
    {
        //�����\�ɂ���
        acceleration.button_flg = true;

        //��]�{�^��ON
        rotate_start.botton_flg = true;
    }
}
