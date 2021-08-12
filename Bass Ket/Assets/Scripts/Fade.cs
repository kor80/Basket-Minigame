using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] public bool isMoving = false; 
    [SerializeField] private float destination = Screen.width / 2f;
    private float speed = 600f;

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

    public void SetDestinationOffscreen()
    {   destination = 2000f;
    }

    public void SetDestinationInScreenMid()
    {   destination = Screen.width / 2f;
    }
}
