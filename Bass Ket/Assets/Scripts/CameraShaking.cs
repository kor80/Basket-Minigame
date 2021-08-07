using UnityEngine;
using Cinemachine;

public class CameraShaking : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float amplitude = 1.5f;
    private float frequency = 3f;
    private float shakeTimer = 0;
    private float shakingTime = 1f;

    void Awake() 
    {   
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        Bucket.scoreDelegate += ShakeCamera;
    }

    void Update() 
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0)
                StopShaking();
        }    
    }

    public void ShakeCamera()
    {   
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultichannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 
        cinemachineBasicMultichannelPerlin.m_AmplitudeGain = amplitude;
        cinemachineBasicMultichannelPerlin.m_FrequencyGain = frequency;
        shakeTimer = shakingTime;
    }

    private void StopShaking()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultichannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 
        cinemachineBasicMultichannelPerlin.m_AmplitudeGain = 0f;
        cinemachineBasicMultichannelPerlin.m_FrequencyGain = 0f;
    }

    void OnDestroy() 
    {
        Bucket.scoreDelegate -= ShakeCamera;    
    }
}
