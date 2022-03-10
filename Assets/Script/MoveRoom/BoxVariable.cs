using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxVariable : MonoBehaviour
{
    //設置用オブジェクトを削除するフラグ
    public bool delete_flg;

    //この箱が子になるフラグ
    public bool become_child = false;

    //Wall用のカウント
    public int child_cnt = 0;

    //設置用のフラグ
    public bool location_flg = true;
}
