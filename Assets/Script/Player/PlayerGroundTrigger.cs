using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundTrigger : MonoBehaviour
{
    //�Փ˃t���O
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
