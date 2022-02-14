using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorColition : MonoBehaviour
{
    public bool cursorhit;

    //歯車に触れたら
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            cursorhit = true;
        }
    }

    //歯車から離れたら
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            cursorhit = false;
        }
    }
}
