using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Can : MonoBehaviour
{
    public Text canYazı;
    public Text süreYazı;
    float zaman = 0f;
    int cansayisi = 0;
    int süresayisi = 300;
    int gecici = 0;
    int dk, sn = 0;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("Can Sayısı") != 10)
        {
            süresayisi = PlayerPrefs.GetInt("Süre");
            Cevirici(süresayisi);
        }
        else
        {
            süreYazı.text = "Filled";
        }
        cansayisi = PlayerPrefs.GetInt("Can Sayısı");
        canYazı.text = cansayisi.ToString();
        InvokeRepeating("CanArttir", 1,1);
    }
    void OnApplicationPause(bool durum)
    {
        if (!durum)
        {
            TimeSpan ts = DateTime.Now.Subtract(DateTime.Parse(PlayerPrefs.GetString("Kapanıs")));
            OyunDevamEtti((int)ts.TotalSeconds);
        }

    }
    public void OyunDevamEtti(int eklenenSüre)
    {
        int öncekisüre = PlayerPrefs.GetInt("Süre");
        if (PlayerPrefs.GetInt("Can Sayısı") != 10)
        {
            if (eklenenSüre < 300)
            {
                if (eklenenSüre > öncekisüre)
                {
                    PlayerPrefs.SetInt("Can Sayısı", PlayerPrefs.GetInt("Can Sayısı") + 1);
                    PlayerPrefs.SetInt("Süre", (300 - (eklenenSüre - öncekisüre)));
                }
                else
                {
                    PlayerPrefs.SetInt("Süre", (öncekisüre - eklenenSüre));
                }
            }
            else
            {
                int can = eklenenSüre / 300;
                int eksisüre = eklenenSüre % 300;
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
            süresayisi = PlayerPrefs.GetInt("Süre");
            cansayisi = PlayerPrefs.GetInt("Can Sayısı");
        }
    }
    void CanArttir()
    {
        if (cansayisi != 10)
        {           
            zaman += 1;
            gecici = Convert.ToInt32(süresayisi - zaman);
            Cevirici(gecici);
            if (zaman >= süresayisi)
            {
                cansayisi++;
                canYazı.text = (cansayisi).ToString();
                PlayerPrefs.SetInt("Can Sayısı", cansayisi);
                zaman = 0;
            }
            PlayerPrefs.SetInt("Süre", gecici);
            cansayisi = PlayerPrefs.GetInt("Can Sayısı");
        }
        else
        {
            PlayerPrefs.SetInt("Süre", süresayisi);
            süreYazı.text = "Filled";
        }
    }
    void Cevirici(int gecici)
    {
        if (gecici > 59)
        {
            dk = gecici / 60;
            sn = gecici % 60;
        }
        else
        {
            dk = 0;
            sn = gecici;
        }
        if (sn == 0)
        {
            süreYazı.text = dk.ToString() + ":00";
        }
        else if (sn < 10 && sn > 0)
        {
            süreYazı.text = dk.ToString() + ":0" + sn.ToString();
        }
        else
        {
            süreYazı.text = dk.ToString() + ":" + sn.ToString();
        }
    }
}