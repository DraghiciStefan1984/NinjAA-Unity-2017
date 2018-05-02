using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target : MonoBehaviour 
{
    public static int CurrentScore{ get; set;}
    [SerializeField] Text currentScoreText, levelText;
    public static int TargetHit{ get; set; }

	// Use this for initialization
	void Start () 
    {
        TargetHit = 0;
        CurrentScore = PlayerPrefs.GetInt("currentScore");
        currentScoreText.text = "score: " + CurrentScore;
        levelText.text = SceneManager.GetActiveScene().name;

        PlayerPrefs.SetInt("currentLevel", SceneManager.GetActiveScene().buildIndex);
	}
	
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Star")
        {
            CurrentScore++;
            TargetHit++;
            currentScoreText.text = "score: " + CurrentScore;
            PlayerPrefs.SetInt("currentScore", CurrentScore);

            int cScore = PlayerPrefs.GetInt("currentScore");
            int hScore = PlayerPrefs.GetInt("highScore");
            if (cScore >= hScore)
            {
                hScore = cScore;
                PlayerPrefs.SetInt("highScore", hScore);
            }
        }
    }
}
