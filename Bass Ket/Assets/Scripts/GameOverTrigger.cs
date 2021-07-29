using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Ball"))
            SceneLoader.Instance.LoadGameOver();    
    }
}
