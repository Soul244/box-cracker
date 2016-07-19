using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Süre : MonoBehaviour {
    float süresayisi = 60f;
    TextMesh tx;
    int skor,yüksekskor;
    // Use this for initialization
    void Start () {
        tx= GetComponent<TextMesh>();
        süresayisi = 60f;       
    }
	
	// Update is called once per frame
	void Update () {
        sure();
    }
    void sure()
    {
        süresayisi -= Time.deltaTime;
        if (süresayisi <= 10)
        {
            tx.color = Color.red;
        }
        else
        {
            tx.color = Color.green;
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
            return;
        }
        tx.text = süresayisi.ToString("0.0");
    }
}
