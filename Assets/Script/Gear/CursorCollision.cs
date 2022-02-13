using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCollision : MonoBehaviour
{
    public bool cursorhit;

    //歯車に触れたら
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            cursorhit = true;
        }
    }

    //歯車から離れたら
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            cursorhit = false;
        }
    }
}
