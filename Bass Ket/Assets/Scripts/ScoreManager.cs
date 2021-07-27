using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreTxt;
    private int score;

    private void Start() 
    {
        score = 0;
        scoreTxt.text = "0";
        Bucket.scoreDelegate += IncreaseScore;
    }

    public void IncreaseScore()
    {
        score++;
        scoreTxt.text = score.ToString();
    }
}
