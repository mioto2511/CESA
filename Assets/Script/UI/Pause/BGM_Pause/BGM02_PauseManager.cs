using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class BGM01_PauseManager : MonoBehaviour
{
    public void OnClick()
    {
        // �|�[�Y��ʂňꎞ��~���ꂽBGM���ĊJ�������ƊJ�n����
        BGMManager.Instance.UnPause(BGMPath.BGM_001);
    }
}
