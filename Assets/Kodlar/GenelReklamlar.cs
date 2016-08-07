using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class GenelReklamlar : MonoBehaviour {
    private static InterstitialAd interstitial;
    private static BannerView bannerView;

    public static void BannerKaldır()
    {
        if (bannerView != null)
            bannerView.Destroy();
    }
    public static void TamSayfaReklam()
    {
        interstitial.Show();
        RequestInterstitial();
    }
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        RequestInterstitial();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    static void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2207285899275971/8079281645";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-2207285899275971/8079281645";
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
    public static void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2207285899275971/8901820447";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "ca-app-pub-2207285899275971/8901820447";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
}
