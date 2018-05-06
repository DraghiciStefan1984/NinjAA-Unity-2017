using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdMob : MonoBehaviour 
{
    public static AdMob Instance{ get; set;}

	// Use this for initialization
	void Awake ()
    {
        MakeInstance();
	}

    void Start()
    {
        Admob.Instance().initAdmob("ca-app-pub-9390026348098142/6920293154", null);
    }

    void MakeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DisplayBannerAd()
    {
        //Admob.Instance().setTesting(true);
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 1);
    }
}
