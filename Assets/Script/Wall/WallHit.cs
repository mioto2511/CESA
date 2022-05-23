using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour
{
    Vector3 save_pos;

    GameObject parent;

    BoxVariable box_variable;

    private void Awake()
    {
        save_pos = this.transform.localPosition;

        parent = this.transform.parent.gameObject;

        box_variable = parent.GetComponent<BoxVariable>();

        Debug.Log(save_pos);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //à íuÇÃåÎç∑èCê≥
        ErrorCorrection();

        //if (box_variable)
        //{
        //    //à íuÇÃåÎç∑èCê≥
        //    ErrorCorrection();
        //}
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        Debug.Log("hit");

    //        box_variable.box_hit = true;
    //    }
    //}

    void ErrorCorrection()
    { 
        Vector3 pos = this.transform.localPosition;

        pos = save_pos;

        if ((pos.y < 0.0001) && (pos.y > -0.0001))
        {
            pos.y = 0;
        }
        if ((pos.x < 0.0001) && (pos.x > -0.0001))
        {
            pos.x = 0;
        }

        this.transform.localPosition = pos;
    }
}
