using UnityEngine;
using System.Collections;

public class Kutu : MonoBehaviour {
    bool patlak;
    public bool parlak;
    public bool siyah;
    public bool Patlak
    {
        get
        {
            return patlak;
        }

        set
        {
            patlak = value;
        }
    }
    bool patlamaDurumu = false;
    float kaybolmaSayacı;
    void Awake()
    {
        kaybolmaSayacı = KutuKontrol.patlamaEfektiSüresi;
    }
    void OnMouseUpAsButton()
    {

        if (!KutuKontrol.patlamaVar && !AraMenüFonksiyonları.oyunDurdu)
        {
            int kutuÖzelliği = -1;
            if (parlak)
            {
                kutuÖzelliği = 0;
            }
            else if (siyah)
            {
                kutuÖzelliği = 1;
            }
            KutuKontrol.tıklananKutu = new Vector3(transform.position.x, transform.position.y, kutuÖzelliği);
        }
    }
    public void Patlat(GameObject PatlamaEfekti)
    {
        patlak = true;      
        Instantiate(PatlamaEfekti, new Vector3(transform.position.x,transform.position.y,transform.position.z-0.5f), Quaternion.identity);
        KutuKontrol.patlamaVar=patlamaDurumu = true;
        
    }
    public bool AynıRenk(Kutu DiğerKutu)
    {
        if (DiğerKutu == null)
            return false;
        return GetComponent<Renderer>().material.color == DiğerKutu.GetComponent<Renderer>().material.color;
    }
	// Use this for initialization
	void Start () {
        //transform.Rotate(-90, 0, 0);
        patlak = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (patlamaDurumu)
        {
            kaybolmaSayacı -= Time.deltaTime;
            if (kaybolmaSayacı<=0)
            {
                Destroy(gameObject); patlamaDurumu = KutuKontrol.patlamaVar = false;
                return;
            }
        }
        float x = transform.position.x;
        float y = transform.position.y;
        if (y > 0 && !KutuKontrol.KutuVarmı(x, y - 1))
        {
            while (y > 0 && !KutuKontrol.KutuVarmı(x, y - 1))
            {
                y--;
            }
            transform.position = new Vector2(x, y);
        }
        //else if (y==0 && !KutuKontrol.KutuVarmı(x-1,0))
        //{
        //    while (x>0 && !KutuKontrol.KutuVarmı(x-1,0))
        //    {
        //        x--;
        //    }
        //    transform.position = new Vector2(x, y);
        //}
    }
}
