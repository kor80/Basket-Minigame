using System.Collections.Generic;
using UnityEngine;

public class BallSelector : MonoBehaviour
{
    // This class is not flexible and is not optimized YET

    [SerializeField] private List<Ball> ballPrefabs;

    void Start() 
    {   GameManager.Instance.SetBallInstance(ballPrefabs[0]);
    }

    public void SelectStandardBall()
    {   GameManager.Instance.SetBallInstance(ballPrefabs[0]);
    }

    public void SelectMediumBall()
    {   GameManager.Instance.SetBallInstance(ballPrefabs[1]);
    }

    public void SelectOpBall()
    {   GameManager.Instance.SetBallInstance(ballPrefabs[2]);
    }
}
