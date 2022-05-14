using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipWall : MonoBehaviour
{
    private AutoPlayerMove autoPlayerMove;//player用

    private bool slipflg;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player"); //オブジェクトを探す
        autoPlayerMove = player.GetComponent<AutoPlayerMove>();//付いているスクリプトを取得

        slipflg = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(autoPlayerMove.isSlip);
        //if (slipflg == true)
        //{
        //    autoPlayerMove.isSlip = true;
        //}
        //else
        //{
        //    autoPlayerMove.isSlip = false;
        //}
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("E");
    //        autoPlayerMove.isSlip = true;
    //    }
    //}

    //void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("O");
    //        //遅らせて処理するもの
    //        Invoke("DelayMethod", 0.5f);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundTrigger"))
        {
            Debug.Log("E");
            autoPlayerMove.isSlip = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundTrigger"))
        {

            //遅らせて処理するもの
            Invoke("DelayMethod", 0.25f);
        }
    }

    //遅延処理
    private void DelayMethod()
    {
        Debug.Log("O");
        autoPlayerMove.isSlip = false;
    }
}
