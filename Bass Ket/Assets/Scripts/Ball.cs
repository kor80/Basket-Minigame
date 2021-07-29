using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // PARAMETERS
    private float maxForce = 4f;
    private float minForce = 0f;
    private float multiplier = 5f;

    // COMPONENTS
    private Rigidbody ballRb;
    private Vector3 vectorForce;

    // STATES
    private bool isMoving;

    public static Ball Instance {get; private set;}

    private void Awake() 
    {
        Instance = this;
    }

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
            transform.position = new Vector3(0, 0, 0);
            ballRb.useGravity = false;
            ballRb.velocity = Vector3.zero;
            isMoving = false;
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
            SwitchGravity(true);
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

    public void SwitchGravity(bool value)
    {
        ballRb.useGravity = value;
        isMoving = value;
        ballRb.velocity = Vector3.zero;
    }

    public void ActivateThis()
    {   this.gameObject.SetActive(true);
    }
}
