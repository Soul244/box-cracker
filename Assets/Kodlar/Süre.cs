using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Süre : MonoBehaviour {
    double zaman = 0f;
    double gecici = 0f;
    double süresayisi = 60f;
    TextMesh tx;
    // Use this for initialization
    void Start () {
        tx= GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        süresayisi = Convert.ToDouble(tx.text);
        gecici = süresayisi - Math.Round(Time.deltaTime, 2);
        if (gecici<=10)
        {
            tx.color = Color.red;
        }
        else
        {
            tx.color = Color.green;
        }
        if (gecici<=0)
        {
            SceneManager.LoadScene("Ana Menü");
        }
        tx.text = gecici.ToString();
    }
}
