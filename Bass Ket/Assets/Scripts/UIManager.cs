using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text playerText;
    [SerializeField] private Text scoreTxt;

    void Start()
    {
        if(GameManager.Instance.UserNickname != null)
            playerText.text = GameManager.Instance.UserNickname + ":";

        RefreshScore();
        Bucket.scoreDelegate += IncreaseScore;
    }

    public void IncreaseScore()
    {
        GameManager.Instance.IncreaseScore();
        RefreshScore();
    }

    public void RefreshScore()
    {   scoreTxt.text = GameManager.Instance.Score.ToString();
    }
}
