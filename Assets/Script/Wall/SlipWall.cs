using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipWall : MonoBehaviour
{
    private AutoPlayerMove autoPlayerMove;

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
        if (slipflg == true)
        {
            autoPlayerMove.isSlip = true;
        }
        else
        {
            autoPlayerMove.isSlip = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("t");
            slipflg = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("f");
            slipflg = false;
        }
    }
}
