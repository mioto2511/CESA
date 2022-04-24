using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSelect : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("SelectScene");

        Time.timeScale = 1;
    }
}
