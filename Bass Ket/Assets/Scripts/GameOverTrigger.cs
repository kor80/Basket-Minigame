using UnityEngine;
using System.Collections;

public class GameOverTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private ParticleSystem gameOverParticles;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Ball"))
            StartCoroutine(WaitAndLoadGameOver(1f));
    }

    private IEnumerator WaitAndLoadGameOver(float timeToWait)
    {
        audioSource.Play();
        Instantiate(gameOverParticles, Camera.main.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(timeToWait);

        SceneLoader.Instance.LoadGameOver();  
    }
}
