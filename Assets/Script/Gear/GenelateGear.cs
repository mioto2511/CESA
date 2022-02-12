using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenelateGear : MonoBehaviour
{
    public GameObject gear;

    GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.Find("Cursor");
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        //vector3�ɕϊ�
        Vector3 pos = myTransform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);

            Destroy(cursor); //�폜
        }
    }
}