using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Can2 : MonoBehaviour {
    float zaman = 0f;
    int cansayisi = 0;
    int süresayisi = 300;
    int gecici = 0;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("Can Sayısı") != 10)
        {
            süresayisi = PlayerPrefs.GetInt("Süre");
        }
        InvokeRepeating("CanArttir2", 1,1);
    }
    void CanArttir2()
    {
        cansayisi = PlayerPrefs.GetInt("Can Sayısı");
        if (cansayisi != 10)
        {
            zaman += 1;
            gecici = Convert.ToInt32(süresayisi - zaman);
            PlayerPrefs.SetInt("Süre", gecici);
            if (zaman >= süresayisi)
            {
                cansayisi++;
                PlayerPrefs.SetInt("Can Sayısı", cansayisi);
                süresayisi = 300;
                zaman = 0;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Süre", 300);
        }
    }
}
