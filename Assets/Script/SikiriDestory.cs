using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SikiriDestory : MonoBehaviour
{
    private int count = 0;

    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3)
        {
            Destroy(parent);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sikiri"))
        {
            count++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sikiri"))
        {
            count--;
        }
    }
}
