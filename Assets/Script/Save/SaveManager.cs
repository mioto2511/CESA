using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    static string filePath;
    public static SaveData save;

    // 省略。以下のSave関数やLoad関数を呼び出して使用すること

    public static void Save()
    {
        
        string json = JsonUtility.ToJson(save);
        //Debug.Log(json);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); 
        streamWriter.Flush();
        streamWriter.Close();
        
    }

    public static void Load()
    {
        filePath = Application.dataPath + "/.savedata.json";
        save = new SaveData();

        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            save = JsonUtility.FromJson<SaveData>(data);
        }
    }
}
