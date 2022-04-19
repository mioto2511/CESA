using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGear2 : MonoBehaviour
{
    //GearData�̕ϐ����g��
    GearData gear_data;

    // Start is called before the first frame update
    void Start()
    {
        // transform���擾
        Transform mytransform = this.transform;

        //vector3�ɕϊ�
        Vector3 mypos = mytransform.position;

        //�ϐ����g����p�ɂ���
        GameObject obj = GameObject.Find("GearData");
        gear_data = obj.GetComponent<GearData>();

        List<GameObject> UseGearList = new List<GameObject>();// Gear���X�g

        UseGearList = gear_data.GearList;

        // transform���擾
        //Transform usetransform = UseGearList[1].transform;

        //vector3�ɕϊ�
        //Vector3 pos = transform.position;

        //Debug.Log(pos);

        //mypos = pos;

        ////selectcursor�������l��
        //mytransform.position = mypos;  // ���W��ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform mytransform = this.transform;

        //vector3�ɕϊ�
        Vector3 mypos = mytransform.position;

        List<GameObject> UseGearList = new List<GameObject>();// Gear���X�g

        UseGearList = gear_data.GearList;




        //�O����
        Transform transform = UseGearList[0].transform;
        Vector3 pos = transform.position;
        Vector3 old_right_pos = pos;
        Vector3 old_left_pos = pos;
        Vector3 old_up_pos = pos;
        Vector3 old_down_pos = pos;

        Vector3 near_right_pos = pos;
        Vector3 near_left_pos = pos;
        Vector3 near_up_pos = pos;
        Vector3 near_down_pos = pos;

        for (int i = 0; i < UseGearList.Count; i++)
        {
            Transform usetransform = UseGearList[i].transform;

            //vector3�ɕϊ�
            Vector3 usepos = usetransform.position;
            

            //�E������
            if (usepos.x > mypos.x)
            {
                if(Mathf.Abs(usepos.x)> Mathf.Abs(usepos.y))
                {
                    near_right_pos = usepos;
                    Debug.Log(near_right_pos);

                    //�O�����艓���Ȃ�߂�
                    if (near_right_pos.x > old_right_pos.x)
                    {
                        near_right_pos = old_right_pos;
                    }

                    //�ۑ�
                    old_right_pos = near_right_pos;
                }
            }
            //�����ɂ���
            else if (usepos.x < mypos.x)
            {
                if (Mathf.Abs(usepos.x) > Mathf.Abs(usepos.y))
                {
                    near_left_pos = usepos;

                    //�O�����艓���Ȃ�߂�
                    if (near_left_pos.x < old_left_pos.x)
                    {
                        near_left_pos = old_left_pos;
                    }

                    //�ۑ�
                    old_left_pos = near_left_pos;
                }

            }
            else if (usepos.y > mypos.y)
            {
                if (Mathf.Abs(usepos.x) < Mathf.Abs(usepos.y))
                {
                    near_up_pos = usepos;

                    //�O�����艓���Ȃ�߂�
                    if (near_up_pos.x > old_up_pos.x)
                    {
                        near_up_pos = old_up_pos;
                    }

                    //�ۑ�
                    old_up_pos = near_up_pos;
                } 
            }
            else if (usepos.y < mypos.y)
            {
                if (Mathf.Abs(usepos.x) < Mathf.Abs(usepos.y))
                {
                    near_down_pos = usepos;

                    //�O�����艓���Ȃ�߂�
                    if (near_down_pos.x < old_down_pos.x)
                    {
                        near_down_pos = old_down_pos;
                    }

                    //�ۑ�
                    old_down_pos = near_down_pos;
                }
            }
        }

        //Debug.Log(near_up_pos);
        //Debug.Log(near_right_pos);
        //Debug.Log(near_down_pos);
        //Debug.Log(near_left_pos);
    }
}
