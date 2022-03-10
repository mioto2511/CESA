using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public Text textCount;
    private int rotate_cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateRoom.instance.room_hit == true)
        {
            rotate_cnt += 1;
            //RotateRoom.instance.room_hit = false;
        }

        textCount.text = string.Format("{0}", rotate_cnt);
    }
}

