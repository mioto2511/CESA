using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRotateTest : MonoBehaviour
{
    public bool box_hit = false;

    private Collider2D my_collider;

    private Vector3 parent_pos;

    // Start is called before the first frame update
    void Start()
    {
        my_collider = this.GetComponent<Collider2D>();

        GameObject parent = this.transform.parent.gameObject; //オブジェクトを探す
        parent_pos = parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(box_hit);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            box_hit = true;
        }

        if (other.gameObject.CompareTag("ActiveBox"))
        {
            box_hit = true;

            Move();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            box_hit = false;
        }

        if (other.gameObject.CompareTag("ActiveBox"))
        {
            box_hit = false;
        }
    }

    public void Move()
    {
        //this.transform.localRotation = Quaternion.Euler(0, 0, 90);
        //collider.enabled = true;
        this.transform.RotateAround(
            parent_pos,
            Vector3.forward,
            90
            );
    }

    public void ColliderSwith(int id)
    {
        if(id == 0)
        {
            my_collider.enabled = false;
        }
        else if (id == 1)
        {
            my_collider.enabled = true;
        }
    }
}
