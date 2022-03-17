using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCursorCollision : MonoBehaviour
{
    public bool cursor_hit;

    //歯車に触れたら
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Select"))
        {
            cursor_hit = true;
        }
    }

    //歯車から離れたら
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Select"))
        {
            cursor_hit = false;
        }
    }
}
