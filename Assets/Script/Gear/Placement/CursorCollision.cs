using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCollision : MonoBehaviour
{
    public bool cursorhit;

    //éïé‘Ç…êGÇÍÇΩÇÁ
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            cursorhit = true;
            
        }
    }

    //éïé‘Ç©ÇÁó£ÇÍÇΩÇÁ
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            cursorhit = false;
            
        }
    }

    void Update()
    {
        if(cursorhit == true)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (cursorhit == false)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
