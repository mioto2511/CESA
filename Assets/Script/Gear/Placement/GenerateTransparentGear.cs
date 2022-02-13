using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTransparentGear : MonoBehaviour
{
    //��������I�u�W�F�N�g
    public GameObject TransparentGear;
    public GameObject CursorGear;

    //�����t���O
    public bool generateflg = true;

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        //vector3�ɕϊ�
        Vector3 pos = myTransform.position;

        var parent = this.transform;

        //�{�^���������Ǝ���ɐ���
        if (Input.GetKeyDown("joystick button 0"))
        {
            if(generateflg == true)
            {
                //�㉺���E�ɐ���
                Instantiate(TransparentGear, new Vector3(pos.x + 1.0F, pos.y, 0), Quaternion.identity,parent);
                Instantiate(TransparentGear, new Vector3(pos.x, pos.y + 1.0F, 0), Quaternion.identity,parent);
                Instantiate(TransparentGear, new Vector3(pos.x - 1.0F, pos.y, 0), Quaternion.identity,parent);
                Instantiate(TransparentGear, new Vector3(pos.x, pos.y - 1.0F, 0), Quaternion.identity,parent);
                //�΂߂ɐ���
                Instantiate(TransparentGear, new Vector3(pos.x + 0.7F, pos.y + 0.7F, 0), Quaternion.identity,parent);
                Instantiate(TransparentGear, new Vector3(pos.x + 0.7F, pos.y - 0.7F, 0), Quaternion.identity,parent);
                Instantiate(TransparentGear, new Vector3(pos.x - 0.7F, pos.y + 0.7F, 0), Quaternion.identity,parent);
                Instantiate(TransparentGear, new Vector3(pos.x - 0.7F, pos.y - 0.7F, 0), Quaternion.identity,parent);

                Instantiate(CursorGear, new Vector3(pos.x, pos.y + 1.0F, 0), Quaternion.identity,parent);

                //�������t���O��܂�
                generateflg = false;
            }
        }
    }
}
