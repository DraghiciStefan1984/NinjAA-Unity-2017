using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarSpawner : MonoBehaviour 
{
    [SerializeField] private GameObject star;
    [SerializeField] private Text shurikenNumberText, winText;

    public int numberOfStars;
    public static bool CanSpawn{ get; set; }
    private int initialStars;
    private Color winColor;
    int nextLevel;

    void Start()
    {
        initialStars = numberOfStars;
        shurikenNumberText.text = "shurikens: " + numberOfStars;
        winColor = winText.color;
        winColor.a = 0f;
        winText.color = winColor;
        CanSpawn = true;
    }

	// Update is called once per frame
	void Update ()
    {
        //CanSpawn = true;
        if (numberOfStars > 0 && CanSpawn)
        {
            CanSpawn = true;
            SpawnStar();
        }

        if (Target.TargetHit == initialStars)
        {
            if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCount - 2)
            {
                //Target.CurrentScore += initialStars;
                nextLevel = PlayerPrefs.GetInt("currentLevel");

                PlayerPrefs.SetInt("currentScore", Target.CurrentScore);

                int cScore = PlayerPrefs.GetInt("currentScore");
                int hScore = PlayerPrefs.GetInt("highScore");

                if (cScore >= hScore)
                {
                    hScore = cScore;
                    PlayerPrefs.SetInt("highScore", hScore);
                }
                StartCoroutine(LoadNextLevel());
                //nextLevel += 1;
                //SceneManager.LoadScene(nextLevel);
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
            if (CanSpawn)
            {
                //CanSpawn = false;
                Instantiate(star, transform.position, transform.rotation);
                numberOfStars--;
                shurikenNumberText.text = "shurikens: " + numberOfStars;
            }
        }
    }

    IEnumerator LoadNextLevel()
    {
        winColor.a = 1f;
        winText.color = winColor;

        yield return new WaitForSeconds(1.5f);

        nextLevel += 1;
        SceneManager.LoadScene(nextLevel);
    }
}
