using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCollision : MonoBehaviour
{
    public bool gear_hit;

    //•Ô‚ÉG‚ê‚½‚ç
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            gear_hit = true;
            Debug.Log("hit");
        }
    }

    //•Ô‚©‚ç—£‚ê‚½‚ç
    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Gear"))
    //    {
    //        gear_hit = false;
    //    }
    //}
}
