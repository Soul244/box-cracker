using UnityEngine;
using System.Collections;
using System;

public class OyunKapanırken : MonoBehaviour {

    // Use this for initialization
    void OnApplicationQuit()
    {
        //dd.MM.yyyy HH:mm
        PlayerPrefs.SetString("Kapanıs", System.DateTime.Now.ToString());
        PlayerPrefs.SetInt("PatlatılanKutuSayısı", BaşarımKontrol.patlatılanKutuSayısı);
        PlayerPrefs.SetInt("Oyun Açıldı", 0);
    }
    void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus)
        PlayerPrefs.SetString("Kapanıs", System.DateTime.Now.ToString());

    }
}
