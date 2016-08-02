using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeriSayımKontrölü : MonoBehaviour {
    Text yazıAlanı;
    float zaman = 3f;
    Canvas araMenü;
    Image arkaplanResmi;
    float hız;
	// Use this for initialization
	void Start () {
        arkaplanResmi = transform.GetComponentInParent<Image>();
        yazıAlanı = GetComponent<Text>();
        AraMenüFonksiyonları.oyunDurdu = true;
        araMenü = GameObject.Find("Ara Menü").GetComponent<Canvas>();
        hız = 0.025f;
    }
	
	// Update is called once per frame
	void Update () {
        if (!araMenü.enabled)
        {
            zaman -= Time.deltaTime;
            arkaplanResmi.fillAmount = zaman / 3;

            if (zaman <= 0)
            {
                AraMenüFonksiyonları.oyunDurdu = false;
                Destroy(transform.parent.parent.gameObject);
            }
            else if (zaman <= 1.5f)
            {
                arkaplanResmi.color = Color.Lerp(arkaplanResmi.color, Color.red, hız);
            }
            else if (zaman<=2.5f)
            {
                arkaplanResmi.color = Color.Lerp(arkaplanResmi.color, Color.yellow, hız);
            }
            yazıAlanı.text = zaman.ToString("0");
        }
    }
}
