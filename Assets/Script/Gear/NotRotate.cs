using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 def;

    Vector3 pdef;

    void Awake()
    {
        def = transform.localRotation.eulerAngles;
        pdef = transform.localPosition;
    }

    void Update()
    {

        Vector3 _parent = transform.parent.transform.localRotation.eulerAngles;

        //èCê≥â”èä
        transform.localRotation = Quaternion.Euler(def - _parent);

        pdef.x = -1;

        //gameObject.transform.position.x = pdef.x;

        //gameObject.transform.rotation = Quaternion.Euler(0, 0, -176.66f);

    }
}
