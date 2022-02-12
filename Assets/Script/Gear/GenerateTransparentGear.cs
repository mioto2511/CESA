using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTransparentGear : MonoBehaviour
{
    // transformÇéÊìæ
    Transform myTransform;

    //myTransform = this.gameObject.GetComponent<Transform>();

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        myTransform = this.transform;
        Vector3 pos = myTransform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //è„â∫ç∂âEÇ…ê∂ê¨
            Instantiate(prefab, new Vector3(pos.x + 1.0F, 0, 0), Quaternion.identity);
            Instantiate(prefab, new Vector3(0, pos.y + 1.0F, 0), Quaternion.identity);
            Instantiate(prefab, new Vector3(pos.x - 1.0F, 0, 0), Quaternion.identity);
            Instantiate(prefab, new Vector3(0, pos.y - 1.0F, 0), Quaternion.identity);
            //éŒÇﬂÇ…ê∂ê¨
            Instantiate(prefab, new Vector3(pos.x + 1.0F, pos.y + 1.0F, 0), Quaternion.identity);
            Instantiate(prefab, new Vector3(pos.x + 1.0F, pos.y - 1.0F, 0), Quaternion.identity);
            Instantiate(prefab, new Vector3(pos.x - 1.0F, pos.y + 1.0F, 0), Quaternion.identity);
            Instantiate(prefab, new Vector3(pos.x - 1.0F, pos.y - 1.0F, 0), Quaternion.identity);
        }
    }
}
