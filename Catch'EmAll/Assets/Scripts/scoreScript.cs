using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text coinText;
    public Text scoreText;

    private void Start()
    {
        int prevVal = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = "Balls Collected: " + prevVal.ToString()+ " / 7";
        coinText.text = "Coins: " + (prevVal * 10).ToString();
    }

    public void updateScore()
    {
        int newScore = PlayerPrefs.GetInt("HighScore") + 1;
        PlayerPrefs.SetInt("HighScore", newScore);
        scoreText.text = "Balls Collected: " + newScore.ToString()+" / 7";
        coinText.text = "Coins: " + (newScore * 10).ToString();
    }
}
