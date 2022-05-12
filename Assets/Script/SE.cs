using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class SE : MonoBehaviour
{
    private bool soudse;

    // Start is called before the first frame update
    void Start()
    {
        soudse = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateSE();
    }
    private void RotateSE()
    {
        if (RotateRoom.instance.left_rotate == true || RotateRoom.instance.right_rotate == true)
        {
            SEManager.Instance.Play(SEPath.SE_001);
        }
        else
        {
            SEManager.Instance.Stop(SEPath.SE_001);
        }
    }
}
