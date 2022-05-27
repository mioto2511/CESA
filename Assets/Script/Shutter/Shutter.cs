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

    [Header("î‡ÇÃë¨Ç≥")] public float speed = 10f;

    //[Header("î‡L")] public RectTransform shutterL;
    //[Header("î‡R")] public RectTransform shutterR;

    [Header("î‡L")] public Transform shutterL;
    [Header("î‡R")] public Transform shutterR;

    private ZoomCamera zoom_camera;

    private void Start()
    {
        GameObject c = GameObject.Find("Main Camera");
        zoom_camera = c.GetComponent<ZoomCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        //posL = shutterL.anchoredPosition;
        //posR = shutterR.anchoredPosition;
        posL = shutterL.position;
        posR = shutterR.position;

        if (shutter_flg)
        {
            shutter_flg = false;

            Change_Start = true;

            zoom_camera.zoom_shutter_flg = true;

            BGMManager.Instance.Stop(BGMPath.BGM_001);
        }        
    }

    void FixedUpdate()
    {
        if (Change_Start == true)
        {
            //if(posL.x <= -960f)
            //{
            //    posL.x += speed;
            //    shutterL.anchoredPosition = new Vector3(posL.x, 0, 0);

            //    posR.x -= speed;
            //    shutterR.anchoredPosition = new Vector3(posR.x, 0, 0);
            //}
            //if (posL.x <= -481f)
            //{
            //    //Vector3 curPos = shutterL.transform.position;
            //    posL.x = Mathf.Lerp(posL.x, -475, Time.deltaTime * speed);
            //    posR.x = Mathf.Lerp(posR.x, 475, Time.deltaTime * speed);

            //    shutterL.anchoredPosition = new Vector3(posL.x, 0, 0);
            //    shutterR.anchoredPosition = new Vector3(posR.x, 0, 0);
            //}
            //else
            //{
            //    shutterL.anchoredPosition = new Vector3(-480, 0, 0);
            //    shutterR.anchoredPosition = new Vector3(480, 0, 0);
            //}
            if (posL.x <= -4.6f)
            {
                //Vector3 curPos = shutterL.transform.position;
                posL.x = Mathf.Lerp(posL.x, -4.4f, Time.deltaTime * speed);
                posR.x = Mathf.Lerp(posR.x, 4.4f, Time.deltaTime * speed);

                shutterL.position = new Vector3(posL.x, 0, 0);
                shutterR.position = new Vector3(posR.x, 0, 0);
            }
            else
            {
                shutterL.position = new Vector3(-4.6f, 0, 0);
                shutterR.position = new Vector3(4.6f, 0, 0);
            }
        }
    }
}
