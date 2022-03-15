using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive_gearRotate : MonoBehaviour
{
    private bool rflg = false;   //�E��]�t���O
    private bool lflg = false;   //����]�t���O

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform mytransform = this.transform;

        //vector3�ɕϊ�
        Vector3 gScale = mytransform.localScale;

        if (rflg == true)
        {
            //if (gScale.x == 1.0f)  //10�T�C�Y�̎�
            //{
            //    this.transform.Rotate(new Vector3(0, 0, 3));
            //}
            //if (gScale.x == 1.5f)   //15�T�C�Y�̎�
            //{
            //    this.transform.Rotate(new Vector3(0, 0, 2));
            //}
            //if (gScale.x == 2.0f)   //20�T�C�Y�̎�
            //{
            //    this.transform.Rotate(new Vector3(0, 0, 1));
            //}
            this.transform.Rotate(new Vector3(0, 0, 2));
        }
        if (lflg == true)
        {
            //if (gScale.x == 1.0f)  //10�T�C�Y�̎�
            //{
            //    this.transform.Rotate(new Vector3(0, 0, -3));
            //}
            //if (gScale.x == 1.5f)   //15�T�C�Y�̎�
            //{
            //    this.transform.Rotate(new Vector3(0, 0, -2));
            //}
            //if (gScale.x == 2.0f)   //20�T�C�Y�̎�
            //{
            //    this.transform.Rotate(new Vector3(0, 0, -1));
            //}
            this.transform.Rotate(new Vector3(0, 0, -2));
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("hit");
        //�����͂ɓ���������
        if (other.gameObject.CompareTag("RDrive"))
        {
            rflg = true;   // ��]�t���O�I��
            this.tag = "LDrive";
        }
        else if (other.gameObject.CompareTag("LDrive"))
        {
            lflg = true;   // ��]�t���O�I��
            this.tag = "RDrive";
        }
        //���Ԃɓ���������
        else if (other.gameObject.CompareTag("RGear_Connect"))
        {
            rflg = true;   // ��]�t���O�I��
            this.tag = "LDrive";
            //Debug.Log("a");
        }
        else if (other.gameObject.CompareTag("LGear_Connect"))
        {
            lflg = true;   // ��]�t���O�I��
            this.tag = "RDrive";
        }

    }

}
