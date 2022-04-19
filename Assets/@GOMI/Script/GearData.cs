using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearData : MonoBehaviour
{
    public List<GameObject> GearList = new List<GameObject>();// Gearリスト

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] ActiveGear; //代入用のゲームオブジェクト配列を用意

        //Active状態のオブジェクトを探してくる
        ActiveGear = GameObject.FindGameObjectsWithTag("Gear");

        //リストに追加
        for (int i = 0; i < ActiveGear.Length; i++)
        {
            GearList.Add(ActiveGear[i]);
        }

        for (int i = 0; i < GearList.Count; i++)
        {
            //Debug.Log(GearList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
