using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conntion_Gearconnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    //Ú‘±•Ô‚ÆÚ‘±‚µ‚½ó‘Ô
    void OnTriggerStay2D(Collider2D other)
    {
        //•Ô‚É“–‚½‚Á‚½
        if (other.gameObject.CompareTag("RGear"))
        {
            // ‰ñ“]ƒtƒ‰ƒOƒIƒ“
            other.tag = "RGear_Connect";
            //Debug.Log("a");
        }
        else if (other.gameObject.CompareTag("LGear"))
        {
            other.tag = "LGear_Connect";
            //Debug.Log("connect");
        }
    }
}
