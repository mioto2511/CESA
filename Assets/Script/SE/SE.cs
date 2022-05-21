using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class SE : MonoBehaviour
{
    private bool soudse;
    private bool isSE;
    private bool ishitSE;
    //private bool is 

    // Start is called before the first frame update
    void Start()
    {
        soudse = false;
        isSE = true;
        ishitSE = false;
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
                isSE = false;
            }
        }
        else
        {
            SEManager.Instance.Stop(SEPath.SE_001);
            isSE = true;
        }
    }
    private void HitSE()
    {
        if(RotateRoom.instance.room_hit)
        {
            // SE
            if (ishitSE)
            {
                SEManager.Instance.Play(SEPath.SE_002);
                ishitSE = false;
            }
        }
        else
        {
            ishitSE = true;
        }
    }
}
