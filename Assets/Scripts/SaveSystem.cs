using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    // Save game data as binary format at a specific path
    public static void Save(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(getPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    // Loads game data from a saved file, or empty data in case there is no file (startup)
    public static GameData Load()
    {
        if (!File.Exists(getPath()))
        {
            GameData emptyData = new GameData();
            Save(emptyData);
            return emptyData;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(getPath(), FileMode.Open);
        GameData data = formatter.Deserialize(fs) as GameData;
        fs.Close();

        return data;
    }

    private static string getPath()
    {
        return Application.persistentDataPath + "/data.qnd";
    }
}
