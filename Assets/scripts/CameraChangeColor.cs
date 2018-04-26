using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraChangeColor : MonoBehaviour 
{
    public static CameraChangeColor instance;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        Camera.main.backgroundColor = GameManager.instance.CameraColor();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
