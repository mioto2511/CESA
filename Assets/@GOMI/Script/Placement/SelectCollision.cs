using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCollision : MonoBehaviour
{
    public bool cursorhit;

    //���ԂɐG�ꂽ��
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            cursorhit = true;
        }
    }

    //���Ԃ��痣�ꂽ��
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