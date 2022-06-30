using System.IO;
using UnityEngine;

public static class SaveLoadSystem
{
    public static string directery = "/SaveData";
    public static string fileName = "MyData.txt";

    public static void Save(SaveData saveData)
    {
        string dir = Application.persistentDataPath + directery;
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(dir + fileName, json);
        Debug.Log("------------------Saving------------------");
    }


    public static SaveData Load()
    {
        string fullPath = Application.persistentDataPath + directery + fileName;
        SaveData loadData = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            loadData = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("------------------Loading------------------");
        }
        else
        {
            Debug.LogError("------------------Save file not exist------------------");
        }

        return loadData;
    }
}