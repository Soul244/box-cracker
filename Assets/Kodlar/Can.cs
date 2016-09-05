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
    float süresayisi = 300f;
    int gecici = 0;
    int dk, sn = 0;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("Can Sayısı") != 10)
        {
            süresayisi = PlayerPrefs.GetInt("Süre");
            süreYazı.text = süresayisi.ToString();
        }
        else
        {
            süreYazı.text = "Filled";
        }
        canYazı.text = PlayerPrefs.GetInt("Can Sayısı").ToString();
        cansayisi = PlayerPrefs.GetInt("Can Sayısı");
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
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (cansayisi != 10)
        {
            zaman += Time.deltaTime;
            gecici = Convert.ToInt32(süresayisi - int.Parse(zaman.ToString().Split('.')[0]));
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
                PlayerPrefs.SetInt("Süre", gecici);
            }
            else if (sn < 10 && sn > 0)
            {
                süreYazı.text = dk.ToString() + ":0" + sn.ToString();
                PlayerPrefs.SetInt("Süre", gecici);
            }
            else
            {
                süreYazı.text = dk.ToString() + ":" + sn.ToString();
                PlayerPrefs.SetInt("Süre", gecici);
            }
            if (zaman >= süresayisi)
            {
                cansayisi++;
                canYazı.text = (cansayisi).ToString();
                PlayerPrefs.SetInt("Can Sayısı", cansayisi);
                süresayisi = 300f;
                zaman = 0;
            }
            cansayisi = PlayerPrefs.GetInt("Can Sayısı");
        }
        else
        {
            süreYazı.text = "Filled";
        }
    }
}