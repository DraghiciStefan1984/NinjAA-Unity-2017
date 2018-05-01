using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    private Color[] colors= {Color.cyan, Color.green, Color.magenta, Color.red, Color.white, Color.yellow};

    [SerializeField] private StarSpawner starSpawner;
    [SerializeField] int currentLevelIndex;

	// Use this for initialization
	void Awake () 
    {
        MakeInstance();
	}
        
    public void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadGamePlayScene()
    {
        int levelIndex = PlayerPrefs.GetInt("currentLevel");
        if (levelIndex < 3)
        {
            SceneManager.LoadScene("level1");
        }
        else
        {
            SceneManager.LoadScene(levelIndex);
        }
    }

    public void LoadHighScoreScene()
    {
        SceneManager.LoadScene("high_score");
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Reload()
    {
        LoadGamePlayScene();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        PlayerPrefs.SetInt("highScore", 0);
        PlayerPrefs.SetInt("currentLevel", 3);
    }

    public Color CameraColor()
    {
        int rand = Random.Range(0, colors.Length);
        Color cameraColor = colors[rand];
        return cameraColor;
    }
}
