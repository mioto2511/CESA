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
    Player_Localpos player_Localpos;
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
        if (isstop)
        {
            
            
            player.transform.parent = transform.root;
        }
        //else if (!isstop)
        //{
           
        //}

        if (RotateRoom.instance.room_hit)
        {
            player.transform.parent = null;
            //if (player.transform.rotation.z <= 180)
            //{
            //    player.transform.rotation=
            //}
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        PlaySE();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {    
            player_Localpos = player.GetComponent<Player_Localpos>();
            player_Localpos.Wall_stop = true;
            move.move_flg = false;
            isstop = true;
            Debug.Log("stop");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player_Localpos = player.GetComponent<Player_Localpos>();
            player_Localpos.Wall_stop = false;
            move.move_flg = true;
            isstop = false;
            player.transform.parent = null;
        }
    }

    private void PlaySE()
    {
        if (isstop)
        {
            if (isSE)
            {
                SEManager.Instance.Play(SEPath.SE_006, volumeRate:0.1f);
                isSE = false;
            }
        }
        else
        {
            SEManager.Instance.Stop(SEPath.SE_006);
            isSE = true;
        }
    }
}

