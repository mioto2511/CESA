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
    //接続歯車と接続した状態
    void OnTriggerStay2D(Collider2D other)
    {
        //歯車に当たった時
        if (other.gameObject.CompareTag("RGear"))
        {
            // 回転フラグオン
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
