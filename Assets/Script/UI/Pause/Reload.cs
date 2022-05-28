using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    public void OnClickStartButton()
    {
        // Œ»İ‚ÌScene‚ğæ“¾
        Scene loadScene = SceneManager.GetActiveScene();
        // Œ»İ‚ÌƒV[ƒ“‚ğÄ“Ç‚İ‚İ‚·‚é
        //SceneManager.LoadScene(loadScene.name);

        int now = SceneManager.GetActiveScene().buildIndex;
        Fade_Manager.FadeOut(now);


        Time.timeScale = 1;  // ŠÔ’â~
    }
}
