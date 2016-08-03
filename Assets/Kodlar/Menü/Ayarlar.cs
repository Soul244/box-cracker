using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ayarlar : MonoBehaviour {
    bool durum;
	// Use this for initialization
	void Start () {
        //Application.targetFrameRate = 30;
        durum = false;
	}
	
	// Update is called once per frame
	void Update () {	
	}
    public void ayarlar()
    {
        GetComponent<AudioSource>().Play();
        durum = !durum;
        ayarlarıgöster(durum);
    }
    public void ayarlarıkapa()
    {
        ayarlarıgöster(false);
    }
    void ayarlarıgöster(bool durum)
    {
        foreach (Transform child in transform)
        {
            Image img = child.gameObject.GetComponent<Image>();
            Button btn = child.gameObject.GetComponent<Button>();
            Text tx = child.gameObject.GetComponent<Text>();
            if (img!=null)
            {
                img.enabled = durum;
            }
            if (btn!=null)
            {
                btn.enabled = durum;
            }
            if (tx!=null)
            {
                tx.enabled = durum;
            }
        }
        GetComponent<Image>().enabled = durum;
        //GameObject.Find("AyarlarPaneli").GetComponent<Renderer>().enabled = durum;
        //GameObject.Find("Kapatma").GetComponent<Renderer>().enabled =durum;
    }
}
