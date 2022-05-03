using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private float step_time;    // �o�ߎ��ԃJ�E���g�p

    [Header("���̃V�[��")] public int next_scene;

    // Use this for initialization
    void Start()
    {
        step_time = 0.0f;   // �o�ߎ��ԏ�����
    }

    public void NextScene(int next)
    {
        next_scene = next;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shutter"))
        {
            Fade_Manager.FadeOut(next_scene); // �t�F�[�h�C���J�n�A�ԍ��Ńt�F�[�h���scene���w��
        }
       
    }
}