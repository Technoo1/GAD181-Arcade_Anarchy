using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    public static void SaveTickets (ScoreManager score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerdata.AA";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(score);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saving Tickets: " + score.tickets);
    }

    public static PlayerData LoadTickets()
    {
        string path = Application.persistentDataPath + "/playerdata.AA";
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            Debug.Log("Loading tickets: " + data.tickets);
            stream.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteData()
    {
        string path = Application.persistentDataPath + "/playerdata.AA";
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Saved data Deleted.");
        }
        else
        {
            Debug.Log("Saved data not found :(");
        }
    }

}