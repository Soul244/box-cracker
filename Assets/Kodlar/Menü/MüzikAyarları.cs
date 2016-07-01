using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MüzikAyarları : MonoBehaviour {
    public Sprite açık, kapalı;
    void Start()
    {
        //Button b = GetComponent<Button>();
        //b.image.sprite = açık;
    }
    public void MüzikAyarla()
    {
        AudioSource ses = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        ses.mute = ses.mute == true ? false : true;
        Button b = GetComponent<Button>();
        b.image.sprite = ses.mute == true ? kapalı : açık;
    }
}
