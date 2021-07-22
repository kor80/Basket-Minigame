using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // PREFABS
    [SerializeField] private GameObject roundPrefab;

    // PARAMETERS
    private float maxForce = 2.5f;
    private float minForce = 0f;
    private float multiplier = 5f;
    private float distanceBetTrajectoryPoints = 0.2f;
    private int numberOfTrajectoryPoints = 10;


    // COMPONENTS
    private Rigidbody ballRb;
    private Vector3 vectorForce;
    private List<GameObject> trajectoryPoints;

    private void Start() 
    {
        ballRb = GetComponent<Rigidbody>();    
        trajectoryPoints = new List<GameObject>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(-8, 0, 0);
            ballRb.useGravity = false;
            ballRb.velocity = Vector3.zero;
        }    
    }

    private void OnMouseDrag() 
    {
        DragBall();
    }

    private void OnMouseUp() 
    {
        ReleaseBall();
    }

    private void ReleaseBall()
    { 
        ClearTrajectoryoints();
        ballRb.AddForce(vectorForce, ForceMode.Impulse);    
        ballRb.useGravity = true;
    }

    private void DragBall()
    {
        Vector3 dragPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragPoint.z = 0;

        Vector3 dragVector = dragPoint - transform.position;

        float clampedMagnitude = Mathf.Clamp(dragVector.magnitude, minForce, maxForce);

        vectorForce = -1 * dragVector.normalized * clampedMagnitude * multiplier; 

        //GenerateTrajectory(distanceBetTrajectoryPoints, numberOfTrajectoryPoints);  
        GenerateTrajectory(clampedMagnitude);
    }

    #region Experimental Trajectory
    private void GenerateTrajectory(float distanceBetPoints, int pointsNumber)
    {
        ClearTrajectoryoints();

        // Calculating number of cycles based on input parameters
        int cycles = Mathf.CeilToInt(distanceBetPoints * pointsNumber);

        // I generate the trajectory of the ball using parabolic motion
        float xVelocity = vectorForce.x;
        float yVelocity = vectorForce.y;

        // Note that I used the nomenclature "distance between points" and I assign that variable to a time in the equation
        // I do that because if I analyze the positions in greater time values it is poportional to a distance increasing.
        for(float t=distanceBetPoints; t<=cycles; t+=distanceBetPoints)
        {
            float xPos = transform.position.x + (xVelocity * t);
            float yPos = transform.position.y + (yVelocity * t) + (0.5f * Physics.gravity.y * Mathf.Pow(t, 2));

            trajectoryPoints.Add(Instantiate(roundPrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity));
        }  
    }

    private void GenerateTrajectory(float vectorMagnitude)
    {
        ClearTrajectoryoints();

        // Calculating number of cycles based on applied force
        float cycles = (numberOfTrajectoryPoints * distanceBetTrajectoryPoints) / (maxForce / vectorMagnitude);

        // I generate the trajectory of the ball using parabolic motion, so I need force/velocity components
        float xVelocity = vectorForce.x;
        float yVelocity = vectorForce.y;

        // Note that I used the nomenclature "distance between points" and I assign that variable to a time in the equation
        // I do that because if I analyze the positions in greater time values it is poportional to a distance increasing.
        for(float t=distanceBetTrajectoryPoints; t<=cycles; t+=distanceBetTrajectoryPoints)
        {
            float xPos = transform.position.x + (xVelocity * t);
            float yPos = transform.position.y + (yVelocity * t) + (0.5f * Physics.gravity.y * Mathf.Pow(t, 2));

            trajectoryPoints.Add(Instantiate(roundPrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity));
        }  
    }
    #endregion

    private void ClearTrajectoryoints()
    {
        if(trajectoryPoints.Count > 0)
            foreach(GameObject point in trajectoryPoints)
                Destroy(point);
    }
}
