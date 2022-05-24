using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class SlipWall : MonoBehaviour
{
    private AutoPlayerMove autoPlayerMove;//player�p

    private bool isSE;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player"); //�I�u�W�F�N�g��T��
        autoPlayerMove = player.GetComponent<AutoPlayerMove>();//�t���Ă���X�N���v�g���擾
        isSE = true;
    }

    void Update()
    {
        PlaySE();
    }

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

            //�x�点�ď����������
            Invoke("DelayMethod", 0.25f);
        }
    }

    //�x������
    private void DelayMethod()
    {
        Debug.Log("O");
        autoPlayerMove.isSlip = false;
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
    //        //�x�点�ď����������
    //        Invoke("DelayMethod", 0.5f);
    //    }
    //}

    private void PlaySE()
    {
        if (autoPlayerMove.isSlip)
        {
            if (isSE)
            {
                SEManager.Instance.Play(SEPath.SE_007, volumeRate:0.1f);
                isSE = false;
            }
        }
        else
        {
            SEManager.Instance.Stop(SEPath.SE_007);
            isSE = true;
        }
    }
}
