using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Ball"))
        {
            audioSource.Play();
            
            if(SceneLoader.Instance != null)
                SceneLoader.Instance.LoadGameOver();    
        }
    }
}
