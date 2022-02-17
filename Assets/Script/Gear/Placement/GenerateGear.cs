using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGear : MonoBehaviour
{
    //��������I�u�W�F�N�g
    public GameObject wood_gear;
    public GameObject iron_gear;

    //�ގ��p
    enum MATERIAL
    { 
        WOOD,
        IRON,
    };

    private int now_material = (int)MATERIAL.IRON;

    //�����t���O
    public bool generateflg = true;

    //SelectCollision�̕ϐ����g��
    SelectCollision select_collision;

    //GearData�̕ϐ����g��
    GearData gear_data;

    void Start()
    {
        //�ϐ����g����p�ɂ���
        GameObject obj = GameObject.Find("GearData");
        gear_data = obj.GetComponent<GearData>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        //vector3�ɕϊ�
        Vector3 pos = myTransform.position;

        //�ϐ����g����p�ɂ���
        select_collision = GetComponent<SelectCollision>();

        //�ގ��I��
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            now_material = (int)MATERIAL.WOOD;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            now_material = (int)MATERIAL.IRON;
        }


        if (Input.GetKeyDown("joystick button 0"))
        {
            //�ق��̎��Ԃɓ������ĂȂ��Ȃ�
            if(select_collision.cursorhit == false)
            {
                if (generateflg == true)
                {
                    if(now_material == (int)MATERIAL.WOOD)
                    {
                        GameObject newgear = Instantiate(wood_gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                        gear_data.GearList.Add(newgear);// ���X�g�Ƀv���t�@�u��������
                    }
                    else if (now_material == (int)MATERIAL.IRON)
                    {
                        GameObject newgear = Instantiate(iron_gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                        gear_data.GearList.Add(newgear);// ���X�g�Ƀv���t�@�u��������
                    }

                    //�f�o�b�N�p
                    for (int i = 0; i < gear_data.GearList.Count; i++)
                    {
                        //Debug.Log(gear_data.GearList[i]);
                    }

                    //���Ԑ����t���O��܂�
                    generateflg = false;
                }
            }
        }
    }
}
