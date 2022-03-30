using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_Manager : MonoBehaviour
{
    [Header("ワールド開放")] public bool clear = false;
    [Header("シーンビルドの番号")] public int World_No = 0;

    // Update is called once per frame
    void Update()
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
