using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class OpenShutter : MonoBehaviour
{
    private Vector3 posL;
    private Vector3 posR;
    bool Change_Start = false;

    public bool shutter_flg = false;

    [Header("î‡ÇÃë¨Ç≥")] public float speed = 10f;

    [Header("î‡L")] public Transform shutterL;
    [Header("î‡R")] public Transform shutterR;

    private OutCamera out_camera;

    private MoveAicon move_aicon;

    // Start is called before the first frame update
    void Start()
    {
        GameObject c = GameObject.Find("Main Camera");
        out_camera = c.GetComponent<OutCamera>();

        GameObject a = GameObject.Find("Worlds");
        move_aicon = a.GetComponent<MoveAicon>();
    }

    // Update is called once per frame
    void Update()
    {
        posL = shutterL.position;
        posR = shutterR.position;

        if (shutter_flg)
        {
            shutter_flg = false;

            Change_Start = true;

            out_camera.out_flg = true;

            move_aicon.up_flg = true;

            BGMManager.Instance.Stop(BGMPath.BGM_001);

            SEManager.Instance.Play(SEPath.SE_005);
        }
    }

    void FixedUpdate()
    {
        if (Change_Start == true)
        {
            if (posL.x >= -13.5f)
            {
                //Vector3 curPos = shutterL.transform.position;
                posL.x = Mathf.Lerp(posL.x, -13.7f, Time.deltaTime * speed);
                posR.x = Mathf.Lerp(posR.x, 13.7f, Time.deltaTime * speed);

                shutterL.position = new Vector3(posL.x, 0, 0);
                shutterR.position = new Vector3(posR.x, 0, 0);
            }
            else
            {
                shutterL.position = new Vector3(-13.5f, 0, 0);
                shutterR.position = new Vector3(13.5f, 0, 0);
            }
        }
    }
}
