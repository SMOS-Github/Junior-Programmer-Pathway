using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager instance { get; private set; }
    public Color teamColor;
    private string SavePath = "/savefile.json";

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color teamColor;
    }
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.teamColor = teamColor;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + SavePath,json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + SavePath;
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            teamColor = data.teamColor;
        }
    }
}





