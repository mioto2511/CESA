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

        //Debug.Log(save_pos);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //位置の誤差修正
        ErrorCorrection();

        //if (box_variable)
        //{
        //    //位置の誤差修正
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
        Vector3 parent_pos = parent.transform.position;
        
        parent_pos.x = Mathf.Round(parent_pos.x);     //四捨五入
        parent_pos.y = Mathf.Round(parent_pos.y);     //四捨五入
        parent.transform.position = parent_pos;

        //ローカル座標
        Vector3 parent_posl = parent.transform.localPosition;

        parent_posl.x = Mathf.Round(parent_posl.x);     //四捨五入
        parent_posl.y = Mathf.Round(parent_posl.y);     //四捨五入
        parent.transform.localPosition = parent_posl;



        Vector3 pos = this.transform.localPosition;

        pos = save_pos;

        if ((pos.y < 0.001) && (pos.y > -0.001))
        {
            pos.y = 0;
        }
        if ((pos.x < 0.001) && (pos.x > -0.001))
        {
            pos.x = 0;
        }

        this.transform.localPosition = pos;
    }
}
