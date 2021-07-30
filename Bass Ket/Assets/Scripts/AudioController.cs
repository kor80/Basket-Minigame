using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSelected; 
    [SerializeField] private AudioMixer audioMixer;
    public AudioSource audioSource {get; private set;}
    public static AudioController Instance {get; private set; }

    private void Awake() 
    {
        if(AudioController.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LoadVolume();
    }

    public void SetVolume(Slider slider)
    {   
        if(Instance != null)
            Instance.audioMixer.SetFloat("MusicVol", slider.value);
        else
            Debug.Log("Unable to set volume");
    }

    public void LoadVolume()
    {   
        if(Instance != null)
            Instance.audioMixer.SetFloat("MusicVol", DataSaver.Instance.LoadSettings().volume);
        else
            Debug.Log("Unable to load volume");
    }

    public void PlayButtonSelected()
    {   
        if(Instance != null)
            Instance.audioSource.PlayOneShot(buttonSelected);
    }
}
