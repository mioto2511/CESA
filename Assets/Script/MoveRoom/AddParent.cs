using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParent : MonoBehaviour
{
    //RoomCollition変数を使う
    RoomCollition room_collition;
    //BoxVariable
    BoxVariable box_variable;

    // Start is called before the first frame update
    void Start()
    {
        //room_collition = GetComponent<RoomCollition>(); //付いているスクリプトを取得

        GameObject obj = transform.parent.gameObject;
        box_variable = obj.GetComponent<BoxVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (box_variable.become_child == true)
        {
            GameObject parent = this.transform.parent.gameObject;

            Debug.Log("become"+parent);
            parent.transform.parent = GameObject.Find("Room").transform;
            //this.transform.parent = GameObject.Find("Room").transform;

            //room_collition.root = this.transform.parent.parent.gameObject;
            gameObject.AddComponent<RoomCollition>();

            box_variable.child_cnt++;

            //4つの壁にスクリプトを割りあてる
            if (box_variable.child_cnt >= 4)
            {
                box_variable.become_child = false;

            }
            Destroy(this);
        }
    }
}
