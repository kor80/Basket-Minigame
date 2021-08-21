using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] public bool isMoving = false; 
    [SerializeField] private bool goOffScreen;
    private float destination = Screen.width / 2f;
    private float speed = 1200f;

    private void Start() 
    {
        if(goOffScreen)
            destination = 2500f;    
    }

    void Update()
    {
        if(isMoving)
            if(transform.position.x < destination)
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            else
                isMoving = false;
    }

    public void StartFading()
    {   isMoving = true;
    }
}
