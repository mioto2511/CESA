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
    //�ڑ����ԂƐڑ��������
    void OnTriggerStay2D(Collider2D other)
    {
        //���Ԃɓ���������
        if (other.gameObject.CompareTag("RGear"))
        {
            // ��]�t���O�I��
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
