using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenelateGear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject prefab;

    // Update is called once per frame
    void Update()
    {
        // transform‚ðŽæ“¾
        Transform myTransform = this.transform;

        //vector3‚É•ÏŠ·
        Vector3 pos = myTransform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        }
    }
}
