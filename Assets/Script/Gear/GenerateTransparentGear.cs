using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTransparentGear : MonoBehaviour
{
    //��������I�u�W�F�N�g
    public GameObject TransparentGear;
    public GameObject CursorGear;

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

        //�{�^���������Ǝ���ɐ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�㉺���E�ɐ���
            Instantiate(TransparentGear, new Vector3(pos.x + 1.0F, 0, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(0, pos.y + 1.0F, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(pos.x - 1.0F, 0, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(0, pos.y - 1.0F, 0), Quaternion.identity);
            //�΂߂ɐ���
            Instantiate(TransparentGear, new Vector3(pos.x + 1.0F, pos.y + 1.0F, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(pos.x + 1.0F, pos.y - 1.0F, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(pos.x - 1.0F, pos.y + 1.0F, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(pos.x - 1.0F, pos.y - 1.0F, 0), Quaternion.identity);

            Instantiate(CursorGear, new Vector3(0, pos.y + 1.0F, 0), Quaternion.identity);
        }
    }
}
