using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataSave {
    public static void SaveData(PlayerData LocalCopyOfData)
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");

        formatter.Serialize(saveFile, LocalCopyOfData);

        saveFile.Close();
    }

    public static PlayerData LoadData()
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);
            var LocalCopyOfData = (PlayerData)formatter.Deserialize(saveFile);
            saveFile.Close();

            return LocalCopyOfData;
        }
        catch
        {
            return null;
        }
    }
}
