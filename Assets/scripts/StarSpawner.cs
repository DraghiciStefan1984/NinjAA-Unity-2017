using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarSpawner : MonoBehaviour 
{
    [SerializeField] private GameObject star;
    [SerializeField] private Text shurikenNumberText, winText;

    private Color winTextColor;

    public int numberOfStars;
    private bool canSpawn;
    private int initialStars, nextLevel;

    void Start()
    {
        initialStars = numberOfStars;
        shurikenNumberText.text = "shurikens: " + numberOfStars;
        winTextColor = winText.color;
        winTextColor.a = 0f;
        winText.color = winTextColor;
    }

	// Update is called once per frame
	void Update ()
    {
        canSpawn = true;
        if (numberOfStars > 0 && canSpawn == true)
        {
            SpawnStar();
        }

        if (Target.TargetHit == initialStars)
        {
            if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCount - 2)
            {
                Target.CurrentScore += initialStars;
                nextLevel = PlayerPrefs.GetInt("currentLevel");

                //PlayerPrefs.SetInt("currentScore", Target.CurrentScore);

                StartCoroutine(LoadNextLevelSequence());
            }
            else
            {
                PlayerPrefs.SetInt("currentScore", 0);
                SceneManager.LoadScene("coming_soon");
            }
        }
	}

    void SpawnStar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canSpawn = false;
            Instantiate(star, transform.position, transform.rotation);
            numberOfStars--;
            shurikenNumberText.text = "shurikens: " + numberOfStars;
        }
    }
        
    IEnumerator LoadNextLevelSequence()
    {
        winTextColor.a = 1f;
        winText.color = winTextColor;
        yield return new WaitForSeconds(1.5f);
        LoadNextLevel();
    }

    void LoadNextLevel()
    {
        nextLevel += 1;
        SceneManager.LoadScene(nextLevel);
    }
}
