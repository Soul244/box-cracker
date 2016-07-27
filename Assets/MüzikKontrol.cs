using UnityEngine;
using System.Collections;

public class MüzikKontrol : MonoBehaviour {
    public AudioClip[] Müzikler;
    AudioSource sesKaynağı;
    float beklemeSüresi = 0;
    int müzikSırası = 0;
    public void MüzikAçKapa()
    {
        sesKaynağı.enabled = !sesKaynağı.enabled;
    }
    void MüzikOynat()
    {
        sesKaynağı.clip = Müzikler[müzikSırası];
        sesKaynağı.Play();
        beklemeSüresi = Müzikler[müzikSırası].length;
        müzikSırası++;
        if (müzikSırası==Müzikler.Length)
        {
            müzikSırası = 0;
        }
    }
    // Use this for initialization
    void Start () {
        sesKaynağı = GetComponent<AudioSource>();
        MüzikOynat();

    }
	
	// Update is called once per frame
	void Update () {
        beklemeSüresi -= Time.deltaTime;
        if (beklemeSüresi<=0)
        {
            MüzikOynat();
        }
	}
}
