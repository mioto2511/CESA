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
        //SceneManager.LoadScene(loadScene.name);

        int now = SceneManager.GetActiveScene().buildIndex;
        Fade_Manager.FadeOut(now);


        Time.timeScale = 1;  // ���Ԓ�~
    }
}
