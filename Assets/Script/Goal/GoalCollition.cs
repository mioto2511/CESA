using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollition : MonoBehaviour
{
    //�q
    private GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;//�I�u�W�F�N�g��T��

        child.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            child.gameObject.SetActive(true);

            //Rigidbody���擾
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //��~
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        } 
    }
}
