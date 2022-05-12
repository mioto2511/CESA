using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class SE : MonoBehaviour
{
    private bool soudse;
    private bool isrSE;
    private bool is 

    // Start is called before the first frame update
    void Start()
    {
        soudse = false;
        isrSE = true;
    }

    // Update is called once per frame
    void Update()
    {
        RotateSE();
        HitSE();
    }
    private void RotateSE()
    {
        if (RotateRoom.instance.left_rotate == true || RotateRoom.instance.right_rotate == true)
        {
            if (isSE)
            {
                SEManager.Instance.Play(SEPath.SE_001);
                isrSE = false;
            }
        }
        else
        {
            SEManager.Instance.Stop(SEPath.SE_001);
            isrSE = true;
        }
    }
    private void HitSE()
    {
        if(RotateRoom.instance.room_hit)
        {
            // SE
            SEManager.Instance.Play(SEPath.SE_002);
        }
    }
}
