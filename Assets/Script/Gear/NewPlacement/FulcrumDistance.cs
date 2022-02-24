using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FulcrumDistance : MonoBehaviour
{
    public float distance;

    public GameObject[] near_obj; //オブジェクト
    

    // Start is called before the first frame update
    void Start()
    {
        near_obj = new GameObject[4];

        near_obj = serchTag(gameObject, "FulcrumGear");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //指定されたタグの中で最も近いものを取得
    GameObject[] serchTag(GameObject this_obj, string tag_name)
    {
        float tmpDis = 0;           //距離用一時変数
        GameObject[] target_obj; //オブジェクト
        target_obj = new GameObject[4];
        int cnt = 0;    //配列のカント用

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tag_name))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, this_obj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (tmpDis <= distance)
            {
                target_obj[cnt] = obs;
                cnt++;
            }
        }

        //最も近かったオブジェクトを返す
        return target_obj;
    }
}
