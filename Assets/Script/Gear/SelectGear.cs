using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGear : MonoBehaviour
{
    //GearData�̕ϐ����g��
    GearData gear_data;

    // Start is called before the first frame update
    void Start()
    {
        // transform���擾
        Transform myTransform = this.transform;

        //�ϐ����g����p�ɂ���
        GameObject obj = GameObject.Find("GearData");
        gear_data = obj.GetComponent<GearData>();

        // transform���擾
        Transform Transform = gear_data.GearList[0].transform;

        //selectcursor�������l��
        myTransform.position = Transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        //vector3�ɕϊ�
        Vector3 mypos = myTransform.position;
    }
}
