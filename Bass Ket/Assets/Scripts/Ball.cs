using UnityEngine;

public class Ball : MonoBehaviour
{
    // PARAMETERS
    protected float maxForce = 6f;
    protected float minForce = 0.5f;
    protected float multiplier = 7f;

    // COMPONENTS
    protected Rigidbody ballRb;
    protected AudioSource audioSource;
    private Vector3 vectorForce;

    // STATES
    private bool isMoving;

    public static Ball Instance {get; protected set;}

    void Awake() 
    {
        Instance = this;

        ballRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();   
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
        if(!isMoving && vectorForce != Vector3.zero)
        {
            if(audioSource)
                audioSource.Play();
            
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

            vectorForce = (clampedMagnitude > minForce) ? (-1 * dragVector.normalized * clampedMagnitude * multiplier) : Vector3.zero; 
 
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
