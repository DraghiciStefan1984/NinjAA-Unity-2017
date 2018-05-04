using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    private Color32[] colors = { new Color32(154, 77, 77, 1), new Color32(141, 16, 16, 1), 
        new Color32(255, 255, 255, 1), new Color32(100, 60, 60, 1), new Color32(84, 84, 84, 1), 
        new Color32(150, 150, 150, 1), new Color32(212, 182, 255, 1), new Color32(85, 93, 178, 1), 
        new Color32(27, 40, 174, 1), new Color32(37, 180, 218, 1), new Color32(74, 125, 140, 1), 
        new Color32(74, 140, 112, 1), new Color32(17, 88, 59, 1), new Color32(67, 147, 80, 1), 
        new Color32(103, 186, 23, 1), new Color32(87, 114, 61, 1), new Color32(188, 201, 65, 1), 
        new Color32(93, 103, 0, 1), new Color32(163, 108, 10, 1), new Color32(233, 204, 152, 1), 
        new Color32(120, 109, 90, 1), new Color32(92, 62, 8, 1), new Color32(94, 45, 19, 1), new Color32(156, 23, 0, 1)};

    [SerializeField] private StarSpawner starSpawner;
    [SerializeField] int currentLevelIndex;

	// Use this for initialization
	void Awake () 
    {
        MakeInstance();
        AdMob.Instance.DisplayBannerAd();
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
        //AdMob.Instance.DisplayBannerAd();

        int levelIndex = PlayerPrefs.GetInt("currentLevel");
        if (levelIndex < 4)
        {
            SceneManager.LoadScene("Level1");
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

    public void LoadCredits()
    {
        SceneManager.LoadScene("credits");
    }

    public void Reload()
    {
        LoadGamePlayScene();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        //PlayerPrefs.SetInt("highScore", 0);
        PlayerPrefs.SetInt("currentLevel", 4);
    }

    public void RateUs()
    {
        #if UNITY_ANDROID
        Application.OpenURL("market://details?id=enter your android app id");
        #elif UNITY_IPHONE
        Application.OpenURL("market://details?id=enter your ios app id");
        #endif
    }

    public Color CameraColor()
    {
        int rand = Random.Range(0, colors.Length-1);
        return colors[rand];
    }
}
