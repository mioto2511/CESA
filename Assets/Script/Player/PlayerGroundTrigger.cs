using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundTrigger : MonoBehaviour
{
    //è’ìÀÉtÉâÉO
    public bool isOn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            isOn = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("out");
            isOn = false;
        }
        
    }
}
