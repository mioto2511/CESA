using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCollision : MonoBehaviour
{
    public bool gear_hit;

    //歯車に触れたら
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            gear_hit = true;
            Debug.Log("hit");
        }
    }

    //歯車から離れたら
    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Gear"))
    //    {
    //        gear_hit = false;
    //    }
    //}
}
