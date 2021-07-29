using UnityEngine;

public class SettingsMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject resumeBtn;
    
    private void Awake() 
    {
        if(GameManager.Instance.IsPlaying)
            EnableResumeBtn();    
        else
            DisableResumeBtn();
    }

    public void EnableResumeBtn()
    {   resumeBtn.SetActive(true);
    }

    public void DisableResumeBtn()
    {   resumeBtn.SetActive(false);
    }
}
