using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundTrigger : MonoBehaviour
{
    //Õ“Ëƒtƒ‰ƒO
    public bool isOn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("out");
        isOn = false;
    }
}
