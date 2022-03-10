using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLocation : MonoBehaviour
{
    //BoxVariableの変数を使う
    private BoxVariable box_variable;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = transform.parent.gameObject;//オブジェクトを探す
        box_variable = obj.GetComponent<BoxVariable>();//付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if(box_variable.delete_flg == true)
        {
            //設置用のオブジェクトを削除
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Select");
            foreach (GameObject del in objects)
            {
                Destroy(del);
            }

            //削除フラグを折る
            box_variable.delete_flg = false;
        }
    }
}
