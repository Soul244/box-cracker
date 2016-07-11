using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MüzikAyarları : MonoBehaviour
{
    public Sprite açık, kapalı;
    AudioSource ses;
    Button b;
    void Start()
    {
        //Button b = GetComponent<Button>();
        //b.image.sprite = açık;
        ses = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        b = GetComponent<Button>();
        if (PlayerPrefs.GetInt("Ses") == 0)
        {
            ses.mute = true;
            b.image.sprite = kapalı;
        }
        else
        {
            ses.mute = false;
            b.image.sprite = açık;
        }
    }
    public void MüzikAyarla()
    {
        ses = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        b = GetComponent<Button>();
        if (ses.mute)
        {
            Debug.Log("Ses kapalı");
            ses.mute = false;
            b.image.sprite = açık;
            PlayerPrefs.SetInt("Ses", 1);

        }
        else
        {
            Debug.Log("Ses kapalı");
            ses.mute = true;
            b.image.sprite = kapalı;
            PlayerPrefs.SetInt("Ses", 0);
        }
    }
}
