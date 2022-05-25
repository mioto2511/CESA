using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class BGM_PauseManager : MonoBehaviour
{
    public void OnClick()
    {
        BGMManager.Instance.UnPause(BGMPath.BGM_001);
    }
}
