using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private void Awake() 
    {
        if(GameManager.Instance != null)
            Destroy(this.gameObject);

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

    public void LoadBestPlayer()
    {
        
    }
}
