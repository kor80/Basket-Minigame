using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] private float cameraYOffset;
    public delegate void Score();
    public static event Score scoreDelegate; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Ball.Instance.SwitchGravity(false);
            Camera.main.transform.position = new Vector3(
                                                            Camera.main.transform.position.x, 
                                                            Ball.Instance.transform.position.y - cameraYOffset, 
                                                            Camera.main.transform.position.z
                                                        ); 
            if(scoreDelegate != null)
                scoreDelegate();
        }
    }
}
