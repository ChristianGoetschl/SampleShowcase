using System.IO;
using UnityEngine;

public static class ConfigSave
{
    private static readonly string s_configFilePath = "/config.json";

    public static void SaveData<T>(T dataStruct)
    {
        string jsonString = JsonUtility.ToJson(dataStruct, true);
        File.WriteAllText(Application.persistentDataPath + s_configFilePath, jsonString);
    }

    public static void LoadData<T>(ref T dataStruct)
    {
        if (!File.Exists(Application.persistentDataPath + s_configFilePath))
        {
            // if it doesn't exist create the file
            Debug.Log("JSON file doesn't exist. A new one is created and saved at: " + Application.persistentDataPath + s_configFilePath);
            SaveData(dataStruct);
            return;
        }

        string jsonString = File.ReadAllText(Application.persistentDataPath + s_configFilePath);
        // overwrite the old s_ConfigData
        dataStruct = JsonUtility.FromJson<T>(jsonString);
    }
}
