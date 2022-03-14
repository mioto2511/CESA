using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//接続歯車が回ったら部屋の接続フラグをオンにする
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
        if (this.tag == "LGear_Connect")
        {
            box_variable.become_child = true;
            //Debug.Log("b");
        }
        else if(this.tag == "RGear_Connect")
        {
            box_variable.become_child = true;
            //Debug.Log("b");
        }
    }
}
