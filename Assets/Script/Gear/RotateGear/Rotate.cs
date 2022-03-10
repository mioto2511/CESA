using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
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
        Transform mytransform  = this.transform;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        //�����͂ɓ���������
        if (other.gameObject.CompareTag("RDrive"))
        {
            rflg = true;   // ��]�t���O�I��
            this.tag = "LGear";
        }
        else if (other.gameObject.CompareTag("LDrive"))
        {
            lflg = true;   // ��]�t���O�I��
            this.tag = "RGear";
        }
        //���Ԃɓ���������
        else if (other.gameObject.CompareTag("RGear"))
        {
            rflg = true;   // ��]�t���O�I��
            this.tag = "LGear";
        }
        else if (other.gameObject.CompareTag("LGear"))
        {
            lflg = true;   // ��]�t���O�I��
            this.tag = "RGear";
        }

    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    //���ꂽ��
    //    if (other.gameObject.CompareTag("RDrive"))
    //    {
    //        rflg = false;   //��]�t���O�I�t
    //        this.tag = "Gear";
    //    }
    //    else if (other.gameObject.CompareTag("LDrive"))
    //    {
    //        lflg = false;   //��]�t���O�I�t
    //        this.tag = "Gear";
    //    }
    //    //���ꂽ��
    //    else if (other.gameObject.CompareTag("RGear"))
    //    {
    //        rflg = false;   //��]�t���O�I�t
    //        this.tag = "Gear";
    //    }
    //    else if (other.gameObject.CompareTag("LGear"))
    //    {
    //        lflg = false;   //��]�t���O�I�t
    //        this.tag = "Gear";
    //    }
    //}


}
