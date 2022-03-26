using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActive : MonoBehaviour
{
    [SerializeField]
    //�@�|�[�Y�������ɕ\������UI�̃v���n�u
    private GameObject pauseUI;

	private bool pause_flg = false;

    // Start is called before the first frame update
    void Start()
    {
        //���U���g�w�i������
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pause_flg)
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                Time.timeScale = 1;  // ���Ԓ�~
                                     //���U���g�w�i������
                pauseUI.SetActive(false);

                pause_flg = false;
            }
        }
        else
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                Time.timeScale = 0;  // ���Ԓ�~
                                     //���U���g�w�i������
                pauseUI.SetActive(true);

                pause_flg = true;
            }
        }
	}
}
