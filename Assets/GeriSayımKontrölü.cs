using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeriSayımKontrölü : MonoBehaviour {
    Text yazıAlanı;
    float zaman = 3f;
    Canvas araMenü;
	// Use this for initialization
	void Start () {
        yazıAlanı = GetComponent<Text>();
        
        araMenü = GameObject.Find("Ara Menü").GetComponent<Canvas>();

    }
	
	// Update is called once per frame
	void Update () {
        if (!araMenü.enabled)
        {
            zaman -= Time.deltaTime;
            AraMenüFonksiyonları.oyunDurdu = true;
            if (zaman <= 0)
            {
                AraMenüFonksiyonları.oyunDurdu = false;
                Destroy(this.gameObject);
            }
            yazıAlanı.text = zaman.ToString("0.0");
        }
    }
}
