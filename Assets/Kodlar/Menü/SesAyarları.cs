using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SesAyarları : MonoBehaviour {
    public Sprite kapalı, açık;
    void Awake()
    {
        Button b=GetComponent<Button>();
        b.image.sprite = açık;
    }
    public void SesleriAyarla()
    {
        Button b = GetComponent<Button>();
        bool sesKapalı = false;
        if (b.image.sprite.name=="M_Ses Açık")
        {
            sesKapalı = true;
            b.image.sprite = kapalı;
        }
        else
        {
            b.image.sprite = açık;
        }
        
        foreach (AudioSource item in FindObjectsOfType<AudioSource>())
        {
            if (item.name=="Main Camera")
            {
                continue;
            }
            item.GetComponent<AudioSource>().mute = sesKapalı;
        }
    }
}
