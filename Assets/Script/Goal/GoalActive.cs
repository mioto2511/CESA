using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalActive : MonoBehaviour
{
    [SerializeField, Tooltip("生成するゴール")]
    private GameObject goal;

    [SerializeField, Tooltip("ゴールサイズ")]
    private float goal_scale = 0.15f;

    private bool generate_flag = true;

    private RotateStart rotate_start;

    // Start is called before the first frame update
    void Start()
    {
        GameObject s = GameObject.Find("Room"); // オブジェクトを探す
        rotate_start = s.GetComponent<RotateStart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (generate_flag)
        {
            if (this.tag == "RDrive")
            {
                // transformを取得
                Transform myTransform = this.transform;

                //vector3に変換
                Vector3 pos = myTransform.position;

                GameObject goal_obj = Instantiate(goal, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                //スケール変更
                goal_obj.transform.localScale = new Vector3(goal_scale, goal_scale, 0);

                generate_flag = false;

                //回せ無くする
                rotate_start.botton_flg = false;
            }
            else if (this.tag == "LDrive")
            {
                // transformを取得
                Transform myTransform = this.transform;

                //vector3に変換
                Vector3 pos = myTransform.position;

                GameObject goal_obj = Instantiate(goal, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                //スケール変更
                goal_obj.transform.localScale = new Vector3(goal_scale, goal_scale, 0);

                generate_flag = false;

                //回せ無くする
                rotate_start.botton_flg = false;
            }

        }
        
    }
}
