using UnityEngine;

public class BucketSpawner : MonoBehaviour
{
    [SerializeField] private float spawnOffset;
    [SerializeField] private float topBound;
    [SerializeField] private GameObject bucketPrefab;
    [SerializeField] private Vector3 minDistToBall;
    private GameObject bucketObject;

    private void Start() 
    {
        Bucket.scoreDelegate += SpawnBucket; 
        bucketObject = Instantiate(
                                    bucketPrefab, 
                                    GenerateRandomVector(Ball.Instance.transform.position.x + minDistToBall.x, spawnOffset, 0f, topBound), 
                                    Quaternion.Euler(-90f, 0f, 0f)
                                  );    
    }

    public void SpawnBucket()
    {
        Vector3 ballPos = Ball.Instance.transform.position;
        if(ballPos.x >= 0)
            SpawnBucketToLeft(ballPos.x - minDistToBall.x, ballPos.y + minDistToBall.y);
        else
            SpawnBucketToRight(ballPos.x + minDistToBall.x, ballPos.y + minDistToBall.y);
    }

    private void SpawnBucketToLeft(float ballXDistance, float ballYDistance)
    {
        bucketObject.transform.position = GenerateRandomVector(ballXDistance - spawnOffset, ballXDistance, ballYDistance*1.2f, topBound);
        bucketObject.transform.rotation = Quaternion.Euler(-90, 180f, 0f);
    }

    private void SpawnBucketToRight(float ballXDistance, float ballYDistance)
    {
        bucketObject.transform.position = GenerateRandomVector(ballXDistance, ballXDistance + spawnOffset, ballYDistance*1.2f, topBound);
        bucketObject.transform.rotation = Quaternion.Euler(-90, 0f, 0f);
    }

    private Vector3 GenerateRandomVector(float minX, float maxX, float minY, float maxY)
    {
        return new Vector3(
                            Random.Range(minX, maxX), 
                            Random.Range(minY, maxY),
                            0f
                          );
    }

    public void ActivateThis()
    {   this.gameObject.SetActive(true);
    }
}
