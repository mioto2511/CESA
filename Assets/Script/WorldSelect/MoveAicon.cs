using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAicon : MonoBehaviour
{

    [Header("アイコンの速さ")] public float speed = 2f;

    [Header("アイコンの速さUP")] public float up_speed = 2f;

    Vector3 pos;

    public bool up_flg = false;
    private bool down_flg = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;

        down_flg = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (down_flg)
        {
            if(pos.y > 0.01f)
            {
                pos.y -= speed;  
                this.transform.position = new Vector3(0, pos.y, 0);
            }
            else
            {
                this.transform.position = new Vector3(0, 0, 0);
                down_flg = false;
            }
            
        }

        if (up_flg)
        {
            down_flg = false;

            if (pos.y < 10)
            {
                pos.y = Mathf.Lerp(pos.y, 10, Time.deltaTime * up_speed);
                this.transform.position = new Vector3(0, pos.y, 0);
            }
            else
            {
                this.transform.position = new Vector3(0, 10, 0);
                up_flg = false;
            }

        }

    }
}
