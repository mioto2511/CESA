using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParent : MonoBehaviour
{
    //RoomCollition�ϐ����g��
    RoomCollition room_collition;
    //BoxVariable
    BoxVariable box_variable;

    // Start is called before the first frame update
    void Start()
    {
        //room_collition = GetComponent<RoomCollition>(); //�t���Ă���X�N���v�g���擾

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

            //4�̕ǂɃX�N���v�g�����肠�Ă�
            if (box_variable.child_cnt >= 4)
            {
                box_variable.become_child = false;

            }
            Destroy(this);
        }
    }
}
