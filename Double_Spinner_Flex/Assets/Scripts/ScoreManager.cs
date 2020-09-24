using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    int score;   

    private void Start()
    {
        if (FindObjectOfType<FinalFigure>())
        {
            score = PlayerPrefs.GetInt("playerScore");
        }
        scoreText.text = score.ToString();
    }

    public void AddToScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("playerScore", score);
    }
}
