using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SesAyarları : MonoBehaviour {
    public Sprite kapalı, açık;
    public static bool sesDurumu;
    void Awake()
    {
        Button b=GetComponent<Button>();
        b.image.sprite = açık;
        sesDurumu = PlayerPrefs.GetInt("SesDurumu") == 1 ? true : false;
    }
    void Start()
    {
        Button b = GetComponent<Button>();
        b.image.sprite = sesDurumu ? açık : kapalı;
        foreach (AudioSource item in FindObjectsOfType<AudioSource>())
        {
            if (item.name == "Müzik(Clone)")
            {
                continue;
            }
            item.GetComponent<AudioSource>().mute = !sesDurumu;
        }
    }
    public void SesleriAyarla()
    {
        Button b = GetComponent<Button>();
        if (b.image.sprite.name=="M_Ses Açık")
        {
            sesDurumu = false;
            b.image.sprite = kapalı;
        }
        else
        {
            sesDurumu = true;
            b.image.sprite = açık;
        }
        PlayerPrefs.SetInt("SesDurumu", sesDurumu ? 1 : 0);
        foreach (AudioSource item in FindObjectsOfType<AudioSource>())
        {
            if (item.name== "Müzik(Clone)")
            {
                continue;
            }
            item.GetComponent<AudioSource>().mute = !sesDurumu;
        }
    }
}
