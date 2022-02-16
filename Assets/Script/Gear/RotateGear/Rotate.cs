using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
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
        Transform mytransform  = this.transform;

        //vector3に変換
        Vector3 gScale = mytransform.localScale;

        if (rflg == true)
        {
            if (gScale.x == 1.0f)  //10サイズの時
            {
                this.transform.Rotate(new Vector3(0, 0, 3));
            }
            if (gScale.x == 1.5f)   //15サイズの時
            {
                this.transform.Rotate(new Vector3(0, 0, 2));
            }
            if (gScale.x == 2.0f)   //20サイズの時
            {
                this.transform.Rotate(new Vector3(0, 0, 1));
            }
        }
        if (lflg == true)
        {
            if (gScale.x == 1.0f)  //10サイズの時
            {
                this.transform.Rotate(new Vector3(0, 0, -3));
            }
            if (gScale.x == 1.5f)   //15サイズの時
            {
                this.transform.Rotate(new Vector3(0, 0, -2));
            }
            if (gScale.x == 2.0f)   //20サイズの時
            {
                this.transform.Rotate(new Vector3(0, 0, -1));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //原動力に当たった時
        if (other.gameObject.CompareTag("RDrive"))
        {
            rflg = true;   // 回転フラグオン
        }
        else if (other.gameObject.CompareTag("LDrive"))
        {
            lflg = true;   // 回転フラグオン
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //離れたら
        if (other.gameObject.CompareTag("RDrive"))
        {
            rflg = false;   //回転フラグオフ
        }
        else if (other.gameObject.CompareTag("LDrive"))
        {
            lflg = false;   //回転フラグオフ
        }
    }


}
