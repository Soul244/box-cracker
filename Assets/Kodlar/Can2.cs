using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Can2 : MonoBehaviour {
    float zaman = 0f;
    int cansayisi = 0;
    float süresayisi = 300f;
    int gecici = 0;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("Süre")>0)
        {
            süresayisi = PlayerPrefs.GetInt("Süre");
        }
    }	
	// Update is called once per frame
	void Update () {
        cansayisi = PlayerPrefs.GetInt("Can Sayısı");
        if (cansayisi != 10)
        {
            zaman += Time.deltaTime;
            gecici = Convert.ToInt32(süresayisi - int.Parse(zaman.ToString().Split('.')[0]));
            PlayerPrefs.SetInt("Süre", gecici);
            if (zaman >= süresayisi)
            {
                cansayisi++;
                PlayerPrefs.SetInt("Can Sayısı", cansayisi);
                süresayisi = 300f;
                zaman = 0;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Süre", 300);
        }
    }
}
