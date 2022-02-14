using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorColition : MonoBehaviour
{
    public bool cursorhit;

    //éïé‘Ç…êGÇÍÇΩÇÁ
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            cursorhit = true;

        }
    }

    //éïé‘Ç©ÇÁó£ÇÍÇΩÇÁ
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
