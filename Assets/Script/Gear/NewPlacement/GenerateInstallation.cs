using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateInstallation : MonoBehaviour
{
    //FulcrumDistanceの変数を使う
    FulcrumDistance fulcrum_distance;

    [SerializeField, Tooltip("生成する設置位置")]
    private GameObject installation_location;

    [SerializeField, Tooltip("生成するカーソル")]
    private GameObject cursor;

    [SerializeField, Tooltip("DriveとPlayerの距離")]
    private float distance = 0;

    //設置用のフラグ
    public bool location_flg = true;

    //親
    private GameObject parent_obj;

    // Start is called before the first frame update
    void Start()
    {
        fulcrum_distance = GetComponent<FulcrumDistance>();//付いているスクリプトを取得
        
        //親を取得
        parent_obj = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            float tmpDis = 0;           //距離用一時変数
            GameObject player = GameObject.Find("Player");//プレイヤー取得

            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(player.transform.position, this.transform.position);

            if (tmpDis < distance)
            {
                Generate();
            }
        } 
    }

    void Generate()
    {
        //生成
        if (location_flg == true)
        {
            // 支点を取得
            Transform[] installation_transform = new Transform[4];
            Vector3[] installation_pos = new Vector3[4];
            GameObject[] near_obj = new GameObject[4];

            //Driveに近い四つの支点を取得
            near_obj = fulcrum_distance.serchTag(gameObject, "FulcrumGear");

            // 取得
            Transform my_transform = parent_obj.transform;
            Vector3 my_pos = my_transform.position;

            //設置座標
            Vector3[] center_pos = new Vector3[4];

            //親にする
            var parent = parent_obj.transform;

            //4箇所の位置取得
            for (int i = 0; i < installation_transform.Length; i++)
            {
                //支点の座標
                installation_transform[i] = near_obj[i].transform;
                installation_pos[i] = installation_transform[i].position;

                //設置座標
                center_pos[i] = (my_pos + installation_pos[i]) / 2;

                //生成
                GameObject location_obj = Instantiate(installation_location, new Vector3(center_pos[i].x, center_pos[i].y, 0), Quaternion.identity, parent);
                location_obj.transform.localScale = new Vector3(0.375f, 0.375f, 0);

            }

            //設置フラグを折る
            location_flg = false;

            //生成
            GameObject cursor_obj = Instantiate(cursor, new Vector3(my_pos.x, my_pos.y, 0), Quaternion.identity, parent);
            cursor_obj.transform.localScale = new Vector3(0.375f, 0.375f, 0);
        }
    }
}
