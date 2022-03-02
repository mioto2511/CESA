using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Ú‘±•Ô‚ª‰ñ‚Á‚½‚ç•”‰®‚ÌÚ‘±ƒtƒ‰ƒO‚ğƒIƒ“‚É‚·‚é
public class Gear_connectflg : MonoBehaviour
{

    BoxVariable box_variable;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Boxobj = transform.parent.gameObject;
        box_variable = Boxobj.GetComponent<BoxVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "LGear")
        {
            box_variable.become_child = true;
            Debug.Log("b");
        }
        else if(this.tag == "RGear")
        {
            box_variable.become_child = true;
            Debug.Log("b");
        }
    }
}
