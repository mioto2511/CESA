using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string objName;
    //歯車に触れたら
    void OnTriggerStay2D(Collider2D other)
    {
        objName = other.gameObject.name;
        //こいつのトランスのろてのZをとってくる
        //-と+で判断
        Debug.Log(objName);
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    objName = collision.gameObject.name;
    //    Debug.Log(objName);
    //}
}
