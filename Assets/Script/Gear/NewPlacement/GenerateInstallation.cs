using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateInstallation : MonoBehaviour
{
    //FulcrumDistanceの変数を使う
    FulcrumDistance fulcrum_distance;

    //生成するオブジェクト
    public GameObject installation_location;
    public GameObject cursor;

    public bool location_flg = true;

    // Start is called before the first frame update
    void Start()
    {
        //スクリプトを取得
        fulcrum_distance = GetComponent<FulcrumDistance>();
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

            if (tmpDis < 2)
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

            near_obj = fulcrum_distance.serchTag(gameObject, "FulcrumGear");

            // 取得
            Transform my_transform = this.transform;
            Vector3 my_pos = my_transform.position;

            //設置座標
            Vector3[] center_pos = new Vector3[4];

            //親にする
            var parent = this.transform;

            //4箇所の位置取得
            for (int i = 0; i < installation_transform.Length; i++)
            {
                //支点の座標
                installation_transform[i] = near_obj[i].transform;
                installation_pos[i] = installation_transform[i].position;

                //設置座標
                center_pos[i] = (my_pos + installation_pos[i]) / 2;

                //生成
                Instantiate(installation_location, new Vector3(center_pos[i].x, center_pos[i].y, 0), Quaternion.identity, parent);


            }

            //設置フラグを折る
            location_flg = false;

            //生成
            Instantiate(cursor, new Vector3(my_pos.x, my_pos.y, 0), Quaternion.identity, parent);
        }
    }
}
