﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarSpawner : MonoBehaviour 
{
    [SerializeField] private GameObject star;
    [SerializeField] private Text shurikenNumberText;

    public int numberOfStars;
    private bool canSpawn;
    private int initialStars;

    void Start()
    {
        initialStars = numberOfStars;
        shurikenNumberText.text = "shurikens: " + numberOfStars;
    }

	// Update is called once per frame
	void Update ()
    {
        canSpawn = true;
        if (numberOfStars > 0 && canSpawn == true)
        {
            SpawnStar();
        }
        if (Target.CurrentScore == initialStars)
        {
            int nextLevel = PlayerPrefs.GetInt("currentLevel");
            nextLevel+=1;
            SceneManager.LoadScene(nextLevel);
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
}