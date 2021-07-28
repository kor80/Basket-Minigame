using UnityEngine;
using UnityEngine.UI;

public class SettingsLoader : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Awake() 
    {
        if(GameManager.Instance != null)
            GameManager.Instance.LoadSettings(volumeSlider);    
    }
}
