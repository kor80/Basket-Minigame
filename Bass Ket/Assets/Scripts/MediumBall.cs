public class MediumBall : Ball
{
    void Start()
    {
        TrajectoryManager.Instance.SetBallInstance(this.gameObject);    
        TrajectoryManager.Instance.SetTrajectoryParams(0.1f, 12);   
    }
}
