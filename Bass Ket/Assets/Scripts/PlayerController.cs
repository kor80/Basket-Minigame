using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PARAMETERS
    [SerializeField] private float maxForce = 2f;
    private float minForce = 0f;
    [SerializeField] private float multiplier = 10f;

    // COMPONENTS
    private Rigidbody ballRb;

    private void Start() 
    {
        ballRb = GetComponent<Rigidbody>();    
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

    private void OnMouseUp() 
    {
        Vector3 dragPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragPoint.z = 0;

        Vector3 dragVector = dragPoint - transform.position;

        float clampedMagnitude = Mathf.Clamp(dragVector.magnitude, minForce, maxForce);

        ballRb.AddForce(-1 * dragVector.normalized * clampedMagnitude * multiplier, ForceMode.Impulse);    
        ballRb.useGravity = true;
    }
}
