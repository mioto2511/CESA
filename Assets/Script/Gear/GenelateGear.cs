using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenelateGear : MonoBehaviour
{
    public GameObject gear;

    GameObject cursor;

    //�����t���O
    public bool GenerateFlg = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        //vector3�ɕϊ�
        Vector3 pos = myTransform.position;

        cursor = GameObject.Find("Cursor");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(GenerateFlg == true)
            {
                Instantiate(gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            }
        }
    }
}
