using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataSaver : MonoBehaviour
{
    public static DataSaver Instance {get; private set;}

    private void Awake() 
    {   
        if(DataSaver.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;    
        DontDestroyOnLoad(this.gameObject);
    }

    [Serializable]
    public class SettingsValues
    {
        public float volume;
        public SettingsValues(float volume)
        {
            this.volume = volume;
        }
    } 

    [Serializable]
    public class BestPlayer
    {
        public string nickname;
        public int score;
        public BestPlayer(string nickname, int score)
        {
            this.nickname = nickname;
            this.score = score; 
        }
    }

    public void SaveSettings(Slider volumeSlider)
    {
        SettingsValues playerSettings = new SettingsValues(volumeSlider.value);
        string json = JsonUtility.ToJson(playerSettings);
        File.WriteAllText(Application.persistentDataPath + "/settings.json", json);
        Debug.Log("Data Saved!");
    }

    public void SaveBestPlayer()
    {
        BestPlayer bestPlayer = new BestPlayer(GameManager.Instance.UserNickname, GameManager.Instance.Score);
        string json = JsonUtility.ToJson(bestPlayer);
        File.WriteAllText(Application.persistentDataPath + "/bestPlayerData.json", json);
    }

    public void LoadSettings(AudioSource audioSource)
    {
        string path = Application.persistentDataPath + "/settings.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsValues playerSettings = JsonUtility.FromJson<SettingsValues>(json);
            audioSource.volume = playerSettings.volume;
            Debug.Log("Data Loaded!");
        }
    }

    public void LoadSettings(Slider slider)
    {
        string path = Application.persistentDataPath + "/settings.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsValues playerSettings = JsonUtility.FromJson<SettingsValues>(json);
            slider.value = playerSettings.volume;
            Debug.Log("Data Loaded!");
        }
    }

    public BestPlayer LoadBestPlayer()
    {   
        string path = Application.persistentDataPath + "/bestPlayerData.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayer bestPlayer = JsonUtility.FromJson<BestPlayer>(json);
            return bestPlayer;
        }
        return null;
    }
}
