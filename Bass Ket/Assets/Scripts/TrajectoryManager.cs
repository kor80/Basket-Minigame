using System.Collections.Generic;
using UnityEngine;

public class TrajectoryManager : MonoBehaviour
{
    private float distBetTrajectoryPoints = 0.1f;
    private int numOfTrajectoryPoints = 8;
    private List<GameObject> trajectoryPoints;
    private GameObject ball;
    [SerializeField] private GameObject pointPrefab;
    public static TrajectoryManager Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
        InitializePointsList();
    }

    public void GenerateTrajectory(float vectorMagnitude, float maxForce, Vector3 vectorForce)
    {
        ClearTrajectoryPoints();

        // Calculating number of cycles based on applied force
        float cycles = (numOfTrajectoryPoints * distBetTrajectoryPoints) / (maxForce / vectorMagnitude);

        // I generate the trajectory of the ball using parabolic motion, so I need force/velocity components
        float xVelocity = vectorForce.x;
        float yVelocity = vectorForce.y;

        // Note that I used the nomenclature "distance between points" and I assign that variable to a time in the equation
        // I do that because if I analyze the positions in greater time values it is proportional to a distance increasing.
        int pointNumber = 0;
        for(float t=distBetTrajectoryPoints; t<=cycles; t+=distBetTrajectoryPoints)
        {
            float xPos = ball.transform.position.x + (xVelocity * t);
            float yPos = ball.transform.position.y + (yVelocity * t) + (0.5f * Physics.gravity.y * Mathf.Pow(t, 2));

            var point = trajectoryPoints[pointNumber];
            point.transform.position = new Vector3(xPos, yPos, 0f);
            point.SetActive(true);

            pointNumber++;
        }  
    }

    public void ClearTrajectoryPoints()
    {
        if(trajectoryPoints.Count > 0)
            foreach(GameObject point in trajectoryPoints)
                point.SetActive(false);
    }

    private void InitializePointsList()
    {
        if(pointPrefab == null)
        {
            Debug.LogError("You have to insert point prefab in the object which is using this script.");
            return;
        }

        trajectoryPoints = new List<GameObject>();
        for(int i=0; i<numOfTrajectoryPoints; i++)
        {
            var point = Instantiate(pointPrefab, Vector3.zero, Quaternion.identity);
            trajectoryPoints.Add(point);
            point.SetActive(false);
        }
    }

    private void RemovePointsFromList(int numOfPoints)
    {
        if(trajectoryPoints.Count <= numOfPoints)
        {
            trajectoryPoints.Clear();
            return;
        }

        int newSize = trajectoryPoints.Count - numOfPoints;
        for(int i = trajectoryPoints.Count-1; i >= newSize; i--)
        {
            Destroy(trajectoryPoints[i]);
            trajectoryPoints.RemoveAt(i);
        }

        numOfTrajectoryPoints = newSize;
    }

    private void AddPointsToList(int numOfPoints)
    {

        for(int i = 0; i < numOfPoints; i++)
        {
            var point = Instantiate(pointPrefab, Vector3.zero, Quaternion.identity);
            trajectoryPoints.Add(point);
            point.SetActive(false);
        }
            

        numOfTrajectoryPoints += numOfPoints;
    }

    public void SetTrajectoryParams(float newDistBetTrajectoryPoints, int newNumOfTrajectoryPoints)
    {
        if(newNumOfTrajectoryPoints > numOfTrajectoryPoints)
            AddPointsToList(newNumOfTrajectoryPoints - numOfTrajectoryPoints);
        
        if(newNumOfTrajectoryPoints < numOfTrajectoryPoints)
            RemovePointsFromList(numOfTrajectoryPoints - newNumOfTrajectoryPoints);

        distBetTrajectoryPoints = newDistBetTrajectoryPoints;
    }

    public void SetBallInstance(GameObject ballInstance)
    {   ball = ballInstance;
    }
}
