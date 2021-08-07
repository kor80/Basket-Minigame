using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text playerText;
    private Text scoreTxt;

    void Start()
    {
        scoreTxt = gameObject.transform.Find("Score").transform.Find("Score").GetComponent<Text>();

        if(GameManager.Instance != null && GameManager.Instance.UserNickname != null)
            playerText.text = GameManager.Instance.UserNickname + ":";

        RefreshScore();
        Bucket.scoreDelegate += IncreaseScore;
    }

    public void IncreaseScore()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.IncreaseScore();
            RefreshScore();
        }
    }

    public void RefreshScore()
    {   
        if(GameManager.Instance != null)
            scoreTxt.text = GameManager.Instance.Score.ToString();
    }

    void OnDestroy() 
    {
        Bucket.scoreDelegate -= IncreaseScore;    
    }
}
