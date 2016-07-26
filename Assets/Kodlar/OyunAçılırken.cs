using UnityEngine;
using System.Collections;
using System;

public class OyunAçılırken : MonoBehaviour {
    static bool uygun=true;
	// Use this for initialization
    void Awake()
    {
        if (uygun)
        {
            DateTime kapanış = DateTime.Parse(PlayerPrefs.GetString("Kapanıs"));
            DateTime simdikizaman = DateTime.Now;
            TimeSpan fark = simdikizaman.Subtract(kapanış);
            int sonuc = fark.Minutes;
            sonuc /= 5;
            sonuc += PlayerPrefs.GetInt("Can Sayısı");
            PlayerPrefs.SetInt("Can Sayısı", sonuc);
            uygun = false;
        }
    }
}
