using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCollision : MonoBehaviour
{
    public bool cursorhit;

    //éïé‘Ç…êGÇÍÇΩÇÁ
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Select"))
        {
            cursorhit = true;
        }
    }

    //éïé‘Ç©ÇÁó£ÇÍÇΩÇÁ
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Select"))
        {
            cursorhit = false;
        }
    }
}
