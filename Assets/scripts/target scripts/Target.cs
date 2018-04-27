using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target : MonoBehaviour 
{
    public static int CurrentScore{ get; set;}
    [SerializeField] private Text currentScoreText;

	// Use this for initialization
	void Start () 
    {
        CurrentScore = 0;
        currentScoreText.text = "score: 0";
        PlayerPrefs.SetInt("currentLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("currentScore", 0);
        PlayerPrefs.SetInt("highScore", 0);
	}
	
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Star")
        {
            CurrentScore++;
            currentScoreText.text = "score: " + CurrentScore;
            PlayerPrefs.SetInt("currentScore", CurrentScore);
        }
    }
}
