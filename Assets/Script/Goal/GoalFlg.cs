using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFlg : MonoBehaviour
{
    public bool goal_flg = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            goal_flg = true;
        }
    }
}
