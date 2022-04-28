using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlg : MonoBehaviour
{
    public bool goal_flg = false;

    private bool button_flg = false;

    void Update()
    {
        if (goal_flg)
        {
            Invoke("DelayMethod", 0.25f);
        }

        if (button_flg)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("SelectScene");
            }
        }
    }

    //íxâÑèàóù
    private void DelayMethod()
    {
        button_flg = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            goal_flg = true;
        }
    }
}
