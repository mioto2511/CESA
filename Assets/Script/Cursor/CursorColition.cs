using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorColition : MonoBehaviour
{
    public bool cursorhit;

    //���ԂɐG�ꂽ��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            cursorhit = true;
        }
    }

    //���Ԃ��痣�ꂽ��
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            cursorhit = false;
        }
    }
}
