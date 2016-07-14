using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Reklam : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BannerView reklamObjesi = new BannerView(
            "ca-app-pub-2207285899275971/8901820447", AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest reklamiAl = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamiAl);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
