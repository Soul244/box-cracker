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
            int süre = Convert.ToInt32(fark.TotalSeconds); 
            int can = 0;
            int eksisüre = 0;
            int öncekisüre = PlayerPrefs.GetInt("Süre");
            if (süre<300)
            {
                if (süre>öncekisüre)
                {
                    PlayerPrefs.SetInt("Can Sayısı", PlayerPrefs.GetInt("Can Sayısı") + 1);
                    PlayerPrefs.SetInt("Süre", 300-(süre - öncekisüre));
                }
                else
                {
                    PlayerPrefs.SetInt("Süre", PlayerPrefs.GetInt("Süre") - süre);
                }
            }
            else
            {
                can = süre / 300;
                eksisüre = süre % 300;
                if (can>10)
                {
                    PlayerPrefs.SetInt("Can Sayısı", 10);
                }
                else
                {
                    PlayerPrefs.SetInt("Süre", PlayerPrefs.GetInt("Süre") - eksisüre);
                    PlayerPrefs.SetInt("Can Sayısı", PlayerPrefs.GetInt("Can Sayısı") + can);
                }
            }
            uygun = false;
        }
    }
}
