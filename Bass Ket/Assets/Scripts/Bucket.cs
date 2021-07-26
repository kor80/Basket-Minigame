using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] private float cameraYOffset;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Ball.Instance.SwitchGravity(false);
            BucketSpawner.Instance.SpawnBucket();
            Camera.main.transform.position = new Vector3(
                                                            Camera.main.transform.position.x, 
                                                            Ball.Instance.transform.position.y - cameraYOffset, 
                                                            Camera.main.transform.position.z
                                                        ); 
        }
    }
}
