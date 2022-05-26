using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_anim : MonoBehaviour
{

    Animator animator;
    //’n–Ê‚É‚¢‚é‚©‚Ç‚¤‚©
    private GameObject animflg;
    PlayerFall playerFall;
    
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        animflg = GameObject.Find("BoxTrigger");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerFall = animflg.GetComponent<PlayerFall>();
        if (playerFall.fall_flg == true)
        {
            animator.SetBool("Isgrountrigger", false);
        }
        else if (playerFall.fall_flg == false)
        {
            animator.SetBool("Isgrountrigger", true);
        }
    }
}
