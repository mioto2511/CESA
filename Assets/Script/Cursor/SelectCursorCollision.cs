using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCursorCollision : MonoBehaviour
{
    public bool cursor_hit;

    //���ԂɐG�ꂽ��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Select"))
        {
            cursor_hit = true;
        }
    }

    //���Ԃ��痣�ꂽ��
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Select"))
        {
            cursor_hit = false;
        }
    }
}
