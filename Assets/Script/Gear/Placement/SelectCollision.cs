using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCollision : MonoBehaviour
{
    public bool cursorhit;

    //歯車に触れたら
    void OnTriggerStay2D(Collider2D other)
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
