using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject resumeBtn;
    [SerializeField] private Slider volumeSlider;
    
    private void Awake() 
    {
        if(GameManager.Instance != null)
        {
            if(GameManager.Instance.IsPlaying)
                EnableResumeBtn();    
            else
                DisableResumeBtn();

            if(DataSaver.Instance != null)
                volumeSlider.value = DataSaver.Instance.LoadSettings().volume;
        }    
    }

    public void EnableResumeBtn()
    {   resumeBtn.SetActive(true);
    }

    public void DisableResumeBtn()
    {   resumeBtn.SetActive(false);
    }
}
