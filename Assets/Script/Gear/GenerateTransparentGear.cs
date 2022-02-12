using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTransparentGear : MonoBehaviour
{
    //生成するオブジェクト
    public GameObject TransparentGear;
    public GameObject CursorGear;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        //vector3に変換
        Vector3 pos = myTransform.position;

        //ボタンを押すと周りに生成
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //上下左右に生成
            Instantiate(TransparentGear, new Vector3(pos.x + 1.0F, 0, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(0, pos.y + 1.0F, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(pos.x - 1.0F, 0, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(0, pos.y - 1.0F, 0), Quaternion.identity);
            //斜めに生成
            Instantiate(TransparentGear, new Vector3(pos.x + 1.0F, pos.y + 1.0F, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(pos.x + 1.0F, pos.y - 1.0F, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(pos.x - 1.0F, pos.y + 1.0F, 0), Quaternion.identity);
            Instantiate(TransparentGear, new Vector3(pos.x - 1.0F, pos.y - 1.0F, 0), Quaternion.identity);

            Instantiate(CursorGear, new Vector3(0, pos.y + 1.0F, 0), Quaternion.identity);
        }
    }
}
