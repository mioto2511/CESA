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

    void Update()
    {
        //if (cursorhit == true)
        //{
        //    GetComponent<Renderer>().material.color = Color.red;
        //}
        //else if (cursorhit == false)
        //{
        //    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        //}
    }
}
