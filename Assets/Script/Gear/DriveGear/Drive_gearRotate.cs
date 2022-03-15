using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive_gearRotate : MonoBehaviour
{
    private bool rflg = false;   //右回転フラグ
    private bool lflg = false;   //左回転フラグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform mytransform = this.transform;

        //vector3に変換
        Vector3 gScale = mytransform.localScale;

        if (rflg == true)
        {
            //if (gScale.x == 1.0f)  //10サイズの時
            //{
            //    this.transform.Rotate(new Vector3(0, 0, 3));
            //}
            //if (gScale.x == 1.5f)   //15サイズの時
            //{
            //    this.transform.Rotate(new Vector3(0, 0, 2));
            //}
            //if (gScale.x == 2.0f)   //20サイズの時
            //{
            //    this.transform.Rotate(new Vector3(0, 0, 1));
            //}
            this.transform.Rotate(new Vector3(0, 0, 2));
        }
        if (lflg == true)
        {
            //if (gScale.x == 1.0f)  //10サイズの時
            //{
            //    this.transform.Rotate(new Vector3(0, 0, -3));
            //}
            //if (gScale.x == 1.5f)   //15サイズの時
            //{
            //    this.transform.Rotate(new Vector3(0, 0, -2));
            //}
            //if (gScale.x == 2.0f)   //20サイズの時
            //{
            //    this.transform.Rotate(new Vector3(0, 0, -1));
            //}
            this.transform.Rotate(new Vector3(0, 0, -2));
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("hit");
        //原動力に当たった時
        if (other.gameObject.CompareTag("RDrive"))
        {
            rflg = true;   // 回転フラグオン
            this.tag = "LDrive";
        }
        else if (other.gameObject.CompareTag("LDrive"))
        {
            lflg = true;   // 回転フラグオン
            this.tag = "RDrive";
        }
        //歯車に当たった時
        else if (other.gameObject.CompareTag("RGear_Connect"))
        {
            rflg = true;   // 回転フラグオン
            this.tag = "LDrive";
            //Debug.Log("a");
        }
        else if (other.gameObject.CompareTag("LGear_Connect"))
        {
            lflg = true;   // 回転フラグオン
            this.tag = "RDrive";
        }

    }

}
