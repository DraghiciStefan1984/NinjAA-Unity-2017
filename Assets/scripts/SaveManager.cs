using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour 
{
    public static SaveManager instance;

	// Use this for initialization
    void Awake () 
    {
        MakeInstance();
    }
	
	// Update is called once per frame
    public void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetCurrentScore(int currentScore)
    {
        PlayerPrefs.SetInt("currentScore", currentScore);
    }

    public int GetCurrentScore()
    {
        return PlayerPrefs.GetInt("currentScore");
    }

    public void SetHighScore(int highScore)
    {
        highScore = GetHighScore();
        int currentScore = GetCurrentScore();

        if (currentScore >= highScore)
        {
            PlayerPrefs.SetInt("highScore", currentScore);
        }
        else
        {
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    public void SaveCurrentLevel(int currentLevel)
    {
        PlayerPrefs.SetInt("currentLevel", currentLevel);
    }

    public int LoadCurrentLevel()
    {
        return PlayerPrefs.GetInt("currentLevel");
    }

    public void ResetAll()
    {
        SetCurrentScore(0);
        SetHighScore(0);
        SaveCurrentLevel(3);
    }
}
