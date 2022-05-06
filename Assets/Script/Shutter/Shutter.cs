using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shutter : MonoBehaviour
{
    private Vector3 posL;
    private Vector3 posR;
    bool Change_Start = false;

    public bool shutter_flg = false;

    [Header("î‡ÇÃë¨Ç≥")] public float speed = 0.01f;

    [Header("î‡L")] public RectTransform shutterL;
    [Header("î‡R")] public RectTransform shutterR;

    // Update is called once per frame
    void Update()
    {
        posL = shutterL.anchoredPosition;
        posR = shutterR.anchoredPosition;

        if (shutter_flg)
        {
            shutter_flg = false;

            Change_Start = true;

            SoundManager.Instance.PlaySE(SESoundData.SE.Pick);
        }        
    }

    void FixedUpdate()
    {
        if (Change_Start == true)
        {
            if (posL.x <= -181f)
            {
                posL.x += speed;
                shutterL.anchoredPosition = new Vector3(posL.x, 0, 0);

                posR.x -= speed;
                shutterR.anchoredPosition = new Vector3(posR.x, 0, 0);
            }
        }
    }
}
