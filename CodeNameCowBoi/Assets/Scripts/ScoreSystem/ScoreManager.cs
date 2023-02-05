using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface IScoreManager
{
    void UpdateScore(int score);
}

public class ScoreManager : MonoBehaviour, IScoreManager
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void UpdateScore(int score)
    {
        Debug.Log("Score updated: " + score);
    }

    
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
