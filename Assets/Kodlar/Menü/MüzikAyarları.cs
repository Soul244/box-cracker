using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MüzikAyarları : MonoBehaviour
{
    public Sprite açık, kapalı;
    AudioSource ses;
    Button b;
    public GameObject müzikObjesi;
    GameObject müzik;


    void Start()
    {
        //Button b = GetComponent<Button>();
        //b.image.sprite = açık;
        GameObject geçiciMüzikObjesi = GameObject.Find("Müzik(Clone)");
        if (!geçiciMüzikObjesi)
        {
            müzik = Instantiate(müzikObjesi);
        }
        else
        {
            müzik = geçiciMüzikObjesi;
        }
        ses = müzik.GetComponent<AudioSource>();

        DontDestroyOnLoad(müzik);
        b = GetComponent<Button>();
        try
        {
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
        catch
        {

        }
    }
    public void MüzikAyarla()
    {
        ses = müzik.GetComponent<AudioSource>();
        b = GetComponent<Button>();
        if (ses.mute)
        {
            ses.mute = false;
            b.image.sprite = açık;
            PlayerPrefs.SetInt("Ses", 1);

        }
        else
        {
            ses.mute = true;
            b.image.sprite = kapalı;
            PlayerPrefs.SetInt("Ses", 0);
        }
    }
}
