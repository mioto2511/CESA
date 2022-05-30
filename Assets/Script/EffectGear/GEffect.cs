using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEffect : MonoBehaviour
{
    public GameObject effectObject;

    private bool isEffect;

    // Start is called before the first frame update
    void Start()
    {
        isEffect = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isEffect)
        {
            if (other.CompareTag("RGear_Connect") || other.CompareTag("LGear_Connect"))
            {
                //Debug.Log("E");
                Instantiate(effectObject, this.transform.position, Quaternion.identity);
                isEffect = false;
            }
        }
    }
}
