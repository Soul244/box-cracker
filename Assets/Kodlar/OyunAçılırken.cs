using UnityEngine;
using System.Collections;
using System;

public class OyunAçılırken : MonoBehaviour {
    static bool uygun=true;
    public GameObject bağlantı;
    public GameObject Kupa, Skor;
	// Use this for initialization
    void Awake()
    {
        GooglePlayBağlantı gpb = bağlantı.GetComponent<GooglePlayBağlantı>();
        Kupa.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(gpb.BaşarımlarıAç);
        Skor.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(gpb.YüksekSkorlarAç);
        if (!GameObject.Find("GooglePlayBağlantı(Clone)"))
        {
            Instantiate(bağlantı);
        }
        //Application.targetFrameRate = 30;
        if (PlayerPrefs.GetInt("Oyun Kuruldu") == 0)
        {
            PlayerPrefs.SetInt("Can Sayısı", 10); // Debug için şimdilik böyle kalsın
            PlayerPrefs.SetInt("SesDurumu", 1);
            PlayerPrefs.SetInt("Ses", 1);
            PlayerPrefs.SetInt("Oyun Kuruldu", 1);
        }
        if (PlayerPrefs.GetInt("Oyun Açıldı") == 0)
        {
            DateTime kapanış = DateTime.Parse(PlayerPrefs.GetString("Kapanıs"));
            DateTime simdikizaman = DateTime.Now;
            TimeSpan fark = simdikizaman.Subtract(kapanış);
            int süre = Convert.ToInt32(fark.TotalSeconds); 
            int can = 0;
            int eksisüre = 0;
            int öncekisüre = PlayerPrefs.GetInt("Süre");
            if (PlayerPrefs.GetInt("Can Sayısı")!=10)
            {
                if (süre < 300)
                {
                    if (süre > öncekisüre)
                    {
                        PlayerPrefs.SetInt("Can Sayısı", PlayerPrefs.GetInt("Can Sayısı") + 1);
                        PlayerPrefs.SetInt("Süre", 300 - (süre - öncekisüre));
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Süre", öncekisüre - süre);
                    }
                }
                else
                {
                    can = süre / 300;
                    eksisüre = süre % 300;                   
                    if (PlayerPrefs.GetInt("Can Sayısı") + can > 10)
                    {
                        PlayerPrefs.SetInt("Can Sayısı", 10);
                        PlayerPrefs.SetInt("Süre", 300);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Can Sayısı", PlayerPrefs.GetInt("Can Sayısı") + can);
                        PlayerPrefs.SetInt("Süre", öncekisüre - eksisüre);
                    }
                }
                PlayerPrefs.SetInt("Oyun Açıldı", 1);
            }           
        }
    }
}
