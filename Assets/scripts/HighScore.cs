using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour 
{
    [SerializeField] private Text currentScoreText;

    private int currentScoreValue;

	// Use this for initialization
	void Start () 
    {
        currentScoreValue = PlayerPrefs.GetInt("currentScore");
        currentScoreText.text = "current score: " + currentScoreValue;
	}
}
