using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance {get; private set;} 

    private void Awake() 
    {
        if(SceneLoader.Instance != null)
            Destroy(this.gameObject);

        Instance = this;    
    }

    public void LoadGameScene()
    {   SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {   SceneManager.LoadScene(0);
    }

    public void LoadSettingsMenu()
    {   SceneManager.LoadScene("SettingsMenu");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}