using UnityEngine;
using Cinemachine;

public class Bucket : MonoBehaviour
{
    private CinemachineVirtualCamera cmVCam;
    [SerializeField] private float cameraYOffset;
    private AudioSource audioSource;
    public delegate void Score();
    public static event Score scoreDelegate; 

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
        cmVCam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            audioSource.Play();
            Ball.Instance.SwitchGravity(false);
            cmVCam.transform.position = new Vector3(
                                                            Camera.main.transform.position.x, 
                                                            Ball.Instance.transform.position.y - cameraYOffset, 
                                                            Camera.main.transform.position.z
                                                        ); 
            if(scoreDelegate != null)
                scoreDelegate();
        }
    }
}
