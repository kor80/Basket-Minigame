using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Ball"))
            if(SceneLoader.Instance != null)
                SceneLoader.Instance.LoadGameOver();    
    }
}
