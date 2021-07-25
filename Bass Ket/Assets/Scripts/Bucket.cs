using UnityEngine;

public class Bucket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
            Debug.Log(1);
    }
}
