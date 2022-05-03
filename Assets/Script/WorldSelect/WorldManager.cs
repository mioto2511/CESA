using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [Header("ワールド開放")] public bool clear = false;
    [Header("シーンビルドの番号")] public int World_No = 0;

    [Header("ワールドの番号")] public int world_num;

    void Start()
    {
        //現在のworld_numを呼び出す
        int now_world_num = PlayerPrefs.GetInt("WORLD", 1);

        //現在のワールド番号が満たしていたら解放
        if (now_world_num >= world_num)
        {
            clear = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }

    private void ColorChange()
    {
        if (clear == true)
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
