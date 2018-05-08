using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour 
{
    [SerializeField] private Text highScoreText;

    private int currentScoreValue;
    private static int highScoreValue;

	// Use this for initialization
	void Start () 
    {
        currentScoreValue = PlayerPrefs.GetInt("currentScore");
        highScoreValue = PlayerPrefs.GetInt("highScore");

        if (currentScoreValue >= highScoreValue)
        {
            highScoreText.text = "highest score: " + currentScoreValue;
        }
        else
        {
            highScoreText.text = "highest score: " + highScoreValue;
        }
	}
}
