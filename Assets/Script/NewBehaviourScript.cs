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
    //���ԂɐG�ꂽ��
    void OnTriggerStay2D(Collider2D other)
    {
        objName = other.gameObject.name;
        //�����̃g�����X�̂�Ă�Z���Ƃ��Ă���
        //-��+�Ŕ��f
        Debug.Log(objName);
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    objName = collision.gameObject.name;
    //    Debug.Log(objName);
    //}
}
