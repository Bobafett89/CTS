using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    static public int score, HighScore;
    public Text scoreText, highScoreText;

    void Start()
    {
        score = 0;
    }
    private void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
            if (Modes.charge <= 0)
            {
                if (score > HighScore)
                {
                    HighScore = score;
                }
                Sound.Die = true;
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            highScoreText.text = "Highscore: " + HighScore.ToString();
        }
    }

}
