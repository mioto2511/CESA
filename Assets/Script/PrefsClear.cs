#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

/// <summary>
/// PlayerPrefsを初期化するクラス
/// </summary>
public static class PrefsClear
{
    [MenuItem("Tools/Reset PlayerPrefs")]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Reset PlayerPrefs");
    }
}
#endif
