using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParent : MonoBehaviour
{
    //public bool become_child = false;
    //RoomCollition変数を使う
    RoomCollition room_collition;

    // Start is called before the first frame update
    void Start()
    {
        room_collition = GetComponent<RoomCollition>();　//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(room_collition.become_child);
        if (room_collition.become_child == true)
        {
            Debug.Log("A");
            transform.parent = GameObject.Find("Room").transform;
            room_collition.become_child = false;
        }
    }
}
