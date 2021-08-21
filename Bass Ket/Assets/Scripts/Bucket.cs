using UnityEngine;
using System.Collections;
using Cinemachine;

public class Bucket : MonoBehaviour
{
    private CinemachineVirtualCamera cmVCam;
    [SerializeField] private float cameraYOffset;
    [SerializeField] private ParticleSystem scoreParticles;
    private Vector3 scoreParticlesOffset = new Vector3(-1, 0, 0);
    private AudioSource audioSource;
    private ParticleSystem particleObject;
    private Vector3 originalScale;
    public delegate void Score();
    public static event Score scoreDelegate; 
    public delegate void PostScore();
    public static event PostScore postScoreDelegate;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
        cmVCam = FindObjectOfType<CinemachineVirtualCamera>();
        particleObject = Instantiate(scoreParticles, transform.position, Quaternion.identity);
        originalScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
            StartCoroutine(WaitAndScore(1f));
    }

    private IEnumerator WaitAndScore(float timeToWait)
    {
        audioSource.Play();
        Ball.Instance.SwitchGravity(false);
        particleObject.transform.position = Ball.Instance.transform.position;
        particleObject.Play();
        transform.localScale = Vector3.zero;

        if(scoreDelegate != null)
                scoreDelegate();

        yield return new WaitForSeconds(timeToWait);

        transform.localScale = originalScale;
        if(postScoreDelegate != null)
                postScoreDelegate();

        RepositionCamera();
    }

    private void RepositionCamera()
    {
        cmVCam.transform.position = new Vector3(
                                        Camera.main.transform.position.x, 
                                        Ball.Instance.transform.position.y - cameraYOffset, 
                                        Camera.main.transform.position.z
                                        ); 
    }
}
