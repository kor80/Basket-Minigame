using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI newBestScore;
    [SerializeField] private GameObject bestResult; 
    [SerializeField] private TextMeshProUGUI bestPlayerName;
    [SerializeField] private TextMeshProUGUI bestPlayerScore;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerScore;
    private DataSaver.BestPlayer bestPlayer;

    private void Awake() 
    {
        if(GameManager.Instance != null)
        {
            FillTopSide();
            FillUserData();
        }
    }

    private void FillTopSide()
    {
        if(DataSaver.Instance != null)
        {
            bestPlayer = DataSaver.Instance.LoadBestPlayer();
            if(bestPlayer != null && bestPlayer.score >= GameManager.Instance.Score)
                FillBestPlayer();
            else
                NewBestScore();
        }
    }

    private void FillBestPlayer()
    {
        bestResult.SetActive(true);
        bestPlayerName.text = bestPlayer.nickname;
        bestPlayerScore.text = bestPlayer.score.ToString();
    }

    private void NewBestScore()
    {   
        newBestScore.gameObject.SetActive(true);
        DataSaver.Instance.SaveBestPlayer();
    }

    private void FillUserData()
    {
        playerName.text = GameManager.Instance.UserNickname;
        playerScore.text = GameManager.Instance.Score.ToString();
    }
}
