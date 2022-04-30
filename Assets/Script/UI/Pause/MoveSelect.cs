using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelect : MonoBehaviour
{
    private Shutter shutterL;
    private Shutter shutterR;
    private ChangeScene change_scene;

    private int scene = 1;

    void Start()
    {
        GameObject L = GameObject.Find("Canvas/ShutterL"); // オブジェクトを探す
        shutterL = L.GetComponent<Shutter>();

        GameObject R = GameObject.Find("Canvas/ShutterR"); // オブジェクトを探す
        shutterR = R.GetComponent<Shutter>();

        GameObject T = GameObject.Find("Canvas/ShutterTrigger"); // オブジェクトを探す
        change_scene = T.GetComponent<ChangeScene>();
    }

    public void OnClickStartButton()
    {
        shutterL.shutter_flg = true;
        shutterR.shutter_flg = true;

        change_scene.NextScene(scene);

        Time.timeScale = 1;
    }
}
