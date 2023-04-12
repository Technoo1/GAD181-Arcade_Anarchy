using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.SocialPlatforms.Impl;

public static class SaveSystem
{
    public static int currentTickets;
    public static string loadedScene;

    public static void SaveTickets (ScoreManager score)
    {
        GenerateSaveFile(score.Tickets);
    }

    public static PlayerData LoadTickets()
    {
        string path = Application.persistentDataPath + "/playerdata.AA";
        PlayerData data;
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            data = formatter.Deserialize(stream) as PlayerData;
            //Debug.Log("Loading tickets: " + data.tickets);
            stream.Close();
        } else
        {
            Debug.LogWarning("Save file not found in " + path);
            data = GenerateSaveFile(0);
        }
        currentTickets = data.tickets;
        return data;
    }

    private static PlayerData GenerateSaveFile(int tickets)
    {
        string path = Application.persistentDataPath + "/playerdata.AA";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(tickets);

        formatter.Serialize(stream, data);
        stream.Close();
        return data;
    }

    public static void DeleteData()
    {
        //string path = Application.persistentDataPath + "/playerdata.AA";
        //if (File.Exists(path))
        //{
        //    File.Delete(path);
        //    Debug.Log("Saved data Deleted");
        //}
        //else
        //{
        //    Debug.Log("Saved data not found");
        //}
        GenerateSaveFile(0);
    }

}