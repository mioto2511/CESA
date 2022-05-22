using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNumDis : MonoBehaviour
{
    NumDisplay num_display;

    // Start is called before the first frame update
    void Start()
    {
        num_display = this.GetComponent<NumDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
