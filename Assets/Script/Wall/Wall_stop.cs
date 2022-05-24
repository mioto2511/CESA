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
        if (isstop)
        {
            move.move_flg = false;
            player.transform.parent = transform.root;
        }
        else if (!isstop)
        {
            move.move_flg = true;
        }

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
            isstop = true;
            Debug.Log("stop");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
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

