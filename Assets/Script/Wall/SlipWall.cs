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
        GameObject player = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        autoPlayerMove = player.GetComponent<AutoPlayerMove>();//�t���Ă���X�N���v�g���擾

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
