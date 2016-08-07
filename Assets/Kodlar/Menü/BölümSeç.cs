using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class BölümSeç : MonoBehaviour {
    Text tx;
    int can;
    bool oynat;
    InterstitialAd interstitial;
    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2207285899275971/8079281645";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
        string adUnitId = "ca-app-pub-2207285899275971/8079281645";
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }
    public void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        if (caneksilt())
        {
            //int sayı = PlayerPrefs.GetInt("Ara Reklam");
            //PlayerPrefs.SetInt("Ara Reklam", sayı + 1);
            //if (sayı == 5)
            //{
                GenelReklamlar.TamSayfaReklam();
            //    PlayerPrefs.SetInt("Ara Reklam", 0);
            //}
            SceneManager.LoadScene("1");

        }
    }
    // Use this for initialization
    void Start () {
        GenelReklamlar.BannerKaldır();        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
    bool caneksilt()
    {
        if (Social.localUser.authenticated)
        {
            if (Social.localUser.userName == "OmerCD")
            {
                PlayerPrefs.SetInt("Can Sayısı", 10);
            }
        }
        tx = GameObject.Find("Can Sayısı").GetComponent<Text>();
        can = Convert.ToInt16(tx.text);
        if (can > 0)
        {
            oynat = true;
            tx.text = Convert.ToString(can - 1);
            PlayerPrefs.SetInt("Can Sayısı", can - 1);
        }
        else
        {
            oynat = false;
        }
        return oynat;
    }
}
