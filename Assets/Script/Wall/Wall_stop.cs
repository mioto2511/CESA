using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class Wall_stop : MonoBehaviour
{
    private bool isstop;
    private bool isSE;
    public GameObject player;
    private AutoPlayerMove move;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        move = player.GetComponent<AutoPlayerMove>();
        isSE = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isstop)
        {
            move.move_flg = false;
        }
        else if (!isstop)
        {
            move.move_flg = true;
        }

        PlaySE();
    }
    
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isstop = true;
            Debug.Log("stop");
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isstop = false;
        }
    }

    private void PlaySE()
    {
        if (isstop)
        {
            if (isSE)
            {
                SEManager.Instance.Play(SEPath.SE_007);
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
