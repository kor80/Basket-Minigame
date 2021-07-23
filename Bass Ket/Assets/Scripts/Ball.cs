using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // PARAMETERS
    private float maxForce = 2.5f;
    private float minForce = 0f;
    private float multiplier = 5f;

    // COMPONENTS
    private Rigidbody ballRb;
    private Vector3 vectorForce;

    // STATES
    private bool isMoving;

    private void Start() 
    {
        ballRb = GetComponent<Rigidbody>();
        isMoving = false;
    }

    private void Update() 
    {
        #region Testing
        if(Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(-8, 0, 0);
            ballRb.useGravity = false;
            ballRb.velocity = Vector3.zero;
        }    
        #endregion
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
        if(!isMoving)
        {
            TrajectoryManager.Instance.ClearTrajectoryPoints();
            ballRb.AddForce(vectorForce, ForceMode.Impulse);    
            ballRb.useGravity = true;
            isMoving = true;
        }
    }

    private void DragBall()
    {
        if(!isMoving)
        {
            Vector3 dragPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragPoint.z = 0;

            Vector3 dragVector = dragPoint - transform.position;

            float clampedMagnitude = Mathf.Clamp(dragVector.magnitude, minForce, maxForce);

            vectorForce = -1 * dragVector.normalized * clampedMagnitude * multiplier; 

            //GenerateTrajectory(distanceBetTrajectoryPoints, numberOfTrajectoryPoints);  
            TrajectoryManager.Instance.GenerateTrajectory(clampedMagnitude, maxForce, vectorForce);
        }
    }
}
