using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCollision : MonoBehaviour
{
    public bool gear_hit;

    //���ԂɐG�ꂽ��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            gear_hit = true;
            Debug.Log("hit");
        }
    }

    //���Ԃ��痣�ꂽ��
    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Gear"))
    //    {
    //        gear_hit = false;
    //    }
    //}
}
