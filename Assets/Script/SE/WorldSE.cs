using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class WorldSE : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            // BGM�~�߂�
            BGMManager.Instance.Stop(BGMPath.BGM_004);
            // �^�C�g���J��SE
            Debug.Log("worldse");
            SEManager.Instance.Play(SEPath.SE_009,volumeRate:0.5f);
        }
    }
}
