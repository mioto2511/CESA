using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallTrigger : MonoBehaviour
{
    //�Փ˃t���O
    public bool isOn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //�Փˈʒu�Z�o
            Vector2 hitPos = collision.ClosestPoint(this.transform.position);

            //�E������
            if (hitPos.x > transform.position.x)
            {
                Debug.Log("right");
            }
            else if (hitPos.x < transform.position.x)
            {
                Debug.Log("left");
            }

            isOn = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isOn = false;
        }
    }
}
