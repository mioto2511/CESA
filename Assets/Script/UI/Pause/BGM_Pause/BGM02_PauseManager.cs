using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class BGM01_PauseManager : MonoBehaviour
{
    public void OnClick()
    {
        // ポーズ画面で一時停止されたBGMを再開をされると開始する
        BGMManager.Instance.UnPause(BGMPath.BGM_001);
    }
}
