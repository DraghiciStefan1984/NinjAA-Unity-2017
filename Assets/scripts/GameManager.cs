using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    private Color[] colors= {Color.cyan, Color.green, Color.magenta, Color.red, Color.white, Color.yellow};

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
        SceneManager.LoadScene("gameplay");
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

    public void Test()
    {
        Debug.Log("test");
    }

    public Color CameraColor()
    {
        int rand = Random.Range(0, colors.Length);
        Color cameraColor = colors[rand];
        return cameraColor;
    }
}
