using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

    [SerializeField] private StarSpawner starSpawner;
    [SerializeField] int currentLevelIndex;

	// Use this for initialization
	void Awake () 
    {
        MakeInstance();
        //for reseting while testing
        //PlayerPrefs.SetInt("currentScore", 0);
        //PlayerPrefs.SetInt("currentLevel", 4);
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
        AdMob.Instance.DisplayBannerAd();

        int levelIndex = PlayerPrefs.GetInt("currentLevel");
        if (levelIndex < 4)
        {
            SceneManager.LoadScene("Level 1");
        }
        else
        {
            SceneManager.LoadScene(levelIndex);
        }
    }

    public void LoadHighScoreScene()
    {
        AdMob.Instance.DisplayBannerAd();
        SceneManager.LoadScene("high_score");
    }

    public void LoadMainMenuScene()
    {
        AdMob.Instance.DisplayBannerAd();
        SceneManager.LoadScene("main_menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadCredits()
    {
        AdMob.Instance.DisplayBannerAd();
        SceneManager.LoadScene("credits");
    }

    public void Reload()
    {
        AdMob.Instance.DisplayBannerAd();
        LoadGamePlayScene();
    }

    public void Reset()
    {
        AdMob.Instance.DisplayBannerAd();
        SceneManager.LoadScene("Level 1");
        PlayerPrefs.SetInt("currentScore", 0);
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
}
