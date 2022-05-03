#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

/// <summary>
/// PlayerPrefs‚ğ‰Šú‰»‚·‚éƒNƒ‰ƒX
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
