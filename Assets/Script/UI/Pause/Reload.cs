using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    public void OnClickStartButton()
    {
        // ���݂�Scene���擾
        Scene loadScene = SceneManager.GetActiveScene();
        // ���݂̃V�[�����ēǂݍ��݂���
        SceneManager.LoadScene(loadScene.name);

        Time.timeScale = 1;  // ���Ԓ�~
    }
}
