using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour 
{
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text highScoreText;

    private int currentScoreValue;
    private static int highScoreValue;

	// Use this for initialization
	void Start () 
    {
        currentScoreValue = PlayerPrefs.GetInt("currentScore");
        highScoreValue = PlayerPrefs.GetInt("highScore");

        currentScoreText.text = "current score: " + currentScoreValue;

        if (currentScoreValue >= highScoreValue)
        {
            highScoreText.text = "high score: " + currentScoreValue;
        }
        else
        {
            highScoreText.text = "high score: " + highScoreValue;
        }
	}
}
