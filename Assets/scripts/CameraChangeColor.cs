using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraChangeColor : MonoBehaviour 
{
    public static CameraChangeColor instance;
    AudioSource audioSource;

    void Awake()
    {
        MakeInstance();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Camera.main.backgroundColor = new Color32(255, 231, 189, 1);
        audioSource.Play();
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
