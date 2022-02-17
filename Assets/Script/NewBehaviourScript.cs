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
    //•Ô‚ÉG‚ê‚½‚ç
    void OnTriggerStay2D(Collider2D other)
    {
        objName = other.gameObject.name;
        //‚±‚¢‚Â‚Ìƒgƒ‰ƒ“ƒX‚Ì‚ë‚Ä‚ÌZ‚ğ‚Æ‚Á‚Ä‚­‚é
        //-‚Æ+‚Å”»’f
        Debug.Log(objName);
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    objName = collision.gameObject.name;
    //    Debug.Log(objName);
    //}
}
