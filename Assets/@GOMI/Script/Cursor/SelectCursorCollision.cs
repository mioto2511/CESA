using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCursorCollision : MonoBehaviour
{
    public bool cursor_hit;

    //éïé‘Ç…êGÇÍÇΩÇÁ
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Select"))
        {
            cursor_hit = true;
        }
    }

    //éïé‘Ç©ÇÁó£ÇÍÇΩÇÁ
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Select"))
        {
            cursor_hit = false;
        }
    }
}
