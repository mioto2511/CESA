using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;

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
            SEManager.Instance.Play(SEPath.SE_009);
            //�x�点�ď����������
            Invoke("DelayMethod", 0.5f);
        }
    }

    //�x������
    private void DelayMethod()
    {
        SceneManager.LoadScene(next_scene);
    }
}
