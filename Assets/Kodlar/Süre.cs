﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Süre : MonoBehaviour {
    static float süresayisi = 60f;

    int skor,yüksekskor;
    // Use this for initialization
    public Transform LoadingBar;
    public Transform tx;
    float sureoranı = 0;
    string gecici;
    void Start () {
        süresayisi = 60f;
        sureoranı = 1 / süresayisi;
    }
	public static float KalanSüre
    {
        get
        {
            return süresayisi;
        }
        set
        {
            Süre.süresayisi = value;
        }
    }
	// Update is called once per frame
	void Update () {       
        sure();
    }
    void sure()
    {
        gecici = tx.GetComponent<Text>().text;
        if (!AraMenüFonksiyonları.oyunDurdu)
        süresayisi -= Time.deltaTime;       
        if (süresayisi <= 10)
        {
            tx.GetComponent<Text>().color = Color.red;
            LoadingBar.GetComponent<Image>().color = Color.red;
        }
        else
        {
            Color açıkYeşil= new Color32(61, 255, 0, 255);
            tx.GetComponent<Text>().color = new Color32(0, 159, 54, 255);
            LoadingBar.GetComponent<Image>().color = açıkYeşil;
        }
        if (süresayisi <= 0f)
        {
            skor = int.Parse(GameObject.Find("Skor").GetComponent<TextMesh>().text);
            yüksekskor = PlayerPrefs.GetInt("High Score");
            if (skor > yüksekskor)
            {
                PlayerPrefs.SetInt("High Score", skor);
            }
            GameObject.Find("highscore").GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("High Score").ToString();
            GameObject.Find("score").GetComponent<Text>().text = "Score: " + skor.ToString();
            GameObject.Find("Ara Menü").GetComponent<Canvas>().enabled = true;
            AraMenüFonksiyonları.oyunDurdu = AraMenüFonksiyonları.oyunBitti= true;
            return;
        }
        tx.GetComponent<Text>().text = süresayisi.ToString("0");
        if (tx.GetComponent<Text>().text != gecici)
        {
            LoadingBar.GetComponent<Image>().fillAmount = (1f / 60f) * süresayisi;
            //LoadingBar.GetComponent<Image>().fillAmount -= sureoranı;
        }
        else
        {

        }
    }
}
