using UnityEngine;
using System.Collections;

public class OyunKapanırken : MonoBehaviour {

    // Use this for initialization
    void OnApplicationQuit()
    {
        //dd.MM.yyyy HH:mm
        PlayerPrefs.SetString("Kapanıs", System.DateTime.Now.ToString());
        PlayerPrefs.SetInt("PatlatılanKutuSayısı", BaşarımKontrol.patlatılanKutuSayısı);
    }
}
