using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Destory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RGear_Connect"))
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("LGear_Connect"))
        {
            Destroy(this.gameObject);
        }

    }
}
