using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class Shutter : MonoBehaviour
{
    private Vector3 posL;
    private Vector3 posR;
    bool Change_Start = false;

    public bool shutter_flg = false;

    [Header("���̑���")] public float speed = 10f;

    [Header("��L")] public RectTransform shutterL;
    [Header("��R")] public RectTransform shutterR;

    // Update is called once per frame
    void Update()
    {
        posL = shutterL.anchoredPosition;
        posR = shutterR.anchoredPosition;

        if (shutter_flg)
        {
            shutter_flg = false;

            Change_Start = true;

            SEManager.Instance.Play(SEPath.SE_005);
        }        
    }

    void FixedUpdate()
    {
        if (Change_Start == true)
        {
            if (posL.x <= -479f)
            {
                posL.x += speed;
                shutterL.anchoredPosition = new Vector3(posL.x, 0, 0);

                posR.x -= speed;
                shutterR.anchoredPosition = new Vector3(posR.x, 0, 0);
            }
        }
    }
}
