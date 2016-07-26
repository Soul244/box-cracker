using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaşarımKontrol : MonoBehaviour {
    Vector2 anaPozisyon;
    Vector2 alınacakPozisyon;
    bool başarımGöster;
    float sayaç;
    RectTransform pozisyon;
	// Use this for initialization
	void Start ()
    {
        pozisyon = GetComponent<RectTransform>();
        anaPozisyon = pozisyon.localPosition;
        başarımGöster = false;
        alınacakPozisyon = new Vector2(192.1f, 643.3f);
        sayaç = 6f;
    }
	
	// Update is called once per frame
	void Update () {
        if (KutuKontrol.sonPuan>99)
        {
            if (BaşarımKontrolü.BaşarımAç("Çüş"))
            {
                başarımGöster = true;
                transform.GetChild(1).GetComponent<Text>().text = "Çüş";
            }
        }
        if (başarımGöster)
        {
                pozisyon.localPosition = Vector2.Lerp(pozisyon.localPosition, alınacakPozisyon, 0.1f);
            sayaç -= Time.deltaTime;
            if (sayaç<=0)
            {
                pozisyon.localPosition = anaPozisyon;
                sayaç = 6f;
                başarımGöster = false;
            }
        }
	}
}
