using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string UserNickname{get; private set;}
    public int Score{get; private set;}
    public bool IsPlaying {get; private set;}
    public static GameManager Instance {get; private set;}

    private void Awake() 
    {
        if(GameManager.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);    
    }

    private void Start() 
    {
        UserNickname = null;
        StopPlaying();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            SceneLoader.Instance.LoadSettingsMenu();
    }

    public void IncreaseScore()
    {   Score++;
    }

    public void SetUserNickname(string nickname)
    {   UserNickname = nickname;
    }

    public void StartPlaying()
    {   IsPlaying = true;
    }

    public void StopPlayingAndInitializeScore()
    {   
        StopPlaying();
        Score = 0;
    }

    public void StopPlaying()
    {   IsPlaying = false;
    }
}
