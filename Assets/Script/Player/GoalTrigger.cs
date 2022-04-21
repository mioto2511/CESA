using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    //自身のコライダー
    private Collider2D my_collider;

    // Start is called before the first frame update
    void Start()
    {
        //コライダーOFF
        my_collider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColliderSwitch(bool switching)
    {
        if (switching)
        {
            my_collider.enabled = true;
        }
        else
        {
            my_collider.enabled = false;
        }
    }
}
