using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGear2 : MonoBehaviour
{
    //GearDataの変数を使う
    GearData gear_data;

    // Start is called before the first frame update
    void Start()
    {
        // transformを取得
        Transform mytransform = this.transform;

        //vector3に変換
        Vector3 mypos = mytransform.position;

        //変数を使える用にする
        GameObject obj = GameObject.Find("GearData");
        gear_data = obj.GetComponent<GearData>();

        List<GameObject> UseGearList = new List<GameObject>();// Gearリスト

        UseGearList = gear_data.GearList;

        // transformを取得
        //Transform usetransform = UseGearList[1].transform;

        //vector3に変換
        //Vector3 pos = transform.position;

        //Debug.Log(pos);

        //mypos = pos;

        ////selectcursorを初期値へ
        //mytransform.position = mypos;  // 座標を設定
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform mytransform = this.transform;

        //vector3に変換
        Vector3 mypos = mytransform.position;

        List<GameObject> UseGearList = new List<GameObject>();// Gearリスト

        UseGearList = gear_data.GearList;




        //前回情報
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

            //vector3に変換
            Vector3 usepos = usetransform.position;
            

            //右側ある
            if (usepos.x > mypos.x)
            {
                if(Mathf.Abs(usepos.x)> Mathf.Abs(usepos.y))
                {
                    near_right_pos = usepos;
                    Debug.Log(near_right_pos);

                    //前回情報より遠いなら戻す
                    if (near_right_pos.x > old_right_pos.x)
                    {
                        near_right_pos = old_right_pos;
                    }

                    //保存
                    old_right_pos = near_right_pos;
                }
            }
            //左側にある
            else if (usepos.x < mypos.x)
            {
                if (Mathf.Abs(usepos.x) > Mathf.Abs(usepos.y))
                {
                    near_left_pos = usepos;

                    //前回情報より遠いなら戻す
                    if (near_left_pos.x < old_left_pos.x)
                    {
                        near_left_pos = old_left_pos;
                    }

                    //保存
                    old_left_pos = near_left_pos;
                }

            }
            else if (usepos.y > mypos.y)
            {
                if (Mathf.Abs(usepos.x) < Mathf.Abs(usepos.y))
                {
                    near_up_pos = usepos;

                    //前回情報より遠いなら戻す
                    if (near_up_pos.x > old_up_pos.x)
                    {
                        near_up_pos = old_up_pos;
                    }

                    //保存
                    old_up_pos = near_up_pos;
                } 
            }
            else if (usepos.y < mypos.y)
            {
                if (Mathf.Abs(usepos.x) < Mathf.Abs(usepos.y))
                {
                    near_down_pos = usepos;

                    //前回情報より遠いなら戻す
                    if (near_down_pos.x < old_down_pos.x)
                    {
                        near_down_pos = old_down_pos;
                    }

                    //保存
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
