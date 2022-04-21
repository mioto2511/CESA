using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_stop : MonoBehaviour
{
    private bool isstop;
    public GameObject player;
    private AutoPlayerMove move;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        move = player.GetComponent<AutoPlayerMove>();
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
}
