using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    private float step_time;    // �o�ߎ��ԃJ�E���g�p

    // Use this for initialization
    void Start()
    {
        step_time = 0.0f;   // �o�ߎ��ԏ�����
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shutter"))
        {
            Fade_Manager.FadeOut(1); // �t�F�[�h�C���J�n�A�ԍ��Ńt�F�[�h���scene���w��
        }
       
    }
}
