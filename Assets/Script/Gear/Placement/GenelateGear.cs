using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenelateGear : MonoBehaviour
{
    //��������I�u�W�F�N�g
    public GameObject wood_gear;
    public GameObject iron_gear;

    enum MATERIAL
    { 
        WOOD,
        IRON,
    };

    private int material_flg = (int)MATERIAL.WOOD;

    //�����t���O
    public bool GenerateFlg = true;

    //CursorCollision�̕ϐ����g��
    CursorCollision cursor_collision;

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
        cursor_collision = GetComponent<CursorCollision>();

        //�ގ��I��
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            material_flg = (int)MATERIAL.WOOD;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            material_flg = (int)MATERIAL.IRON;
        }


        if (Input.GetKeyDown("joystick button 0"))
        {
            //�ق��̎��Ԃɓ������ĂȂ��Ȃ�
            if(cursor_collision.cursorhit == false)
            {
                if (GenerateFlg == true)
                {
                    if(material_flg == (int)MATERIAL.WOOD)
                    {
                        GameObject newgear = Instantiate(wood_gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                        gear_data.GearList.Add(newgear);// ���X�g�Ƀv���t�@�u��������
                    }
                    else if (material_flg == (int)MATERIAL.IRON)
                    {
                        GameObject newgear = Instantiate(iron_gear, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                        gear_data.GearList.Add(newgear);// ���X�g�Ƀv���t�@�u��������
                    }

                    for (int i = 0; i < gear_data.GearList.Count; i++)
                    {
                        Debug.Log(gear_data.GearList[i]);
                    }
                }
            }
        }
    }
}