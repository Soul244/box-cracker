using UnityEngine;
using System.Collections;

public class Kutu : MonoBehaviour {
    bool patlak;
    public bool parlak;
    public bool siyah;
    public virtual Color Renk
    {
        get { return GetComponent<Renderer>().material.color; }
    }
    int x, y;
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

    public int X
    {
        get
        {
            return x;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
    }

    bool patlamaDurumu = false;
    float kaybolmaSayacı;
    void Awake()
    {
        x = (int)transform.position.x;
        y = (int)transform.position.y;
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
            PuanGöster.yeniKutuyaTıklanıldı = true;
            KutuKontrol.tıklananKutu = new Vector3(x, y, kutuÖzelliği);
        }
    }
    public void Patlat(GameObject PatlamaEfekti)
    {
        patlak = true;      
        Instantiate(PatlamaEfekti, new Vector3(x,y,transform.position.z-0.5f), Quaternion.identity);
        KutuKontrol.patlamaVar=patlamaDurumu = true;
        
    }
    public bool AynıRenk(Kutu DiğerKutu)
    {
        if (DiğerKutu == null)
            return false;
        return Renk == DiğerKutu.Renk;
    }
	// Use this for initialization
	void Start () {
        //transform.Rotate(-90, 0, 0);
        patlak = false;
	}
	
	// Update is called once per frame
	protected void Update () {
        if (patlamaDurumu)
        {
            kaybolmaSayacı -= Time.deltaTime;
            if (kaybolmaSayacı<=0)
            {
                Destroy(gameObject); patlamaDurumu = KutuKontrol.patlamaVar = false;
                return;
            }
        }
        float x = this.x;
        float y = this.y;
        if (y > 0 && !KutuKontrol.KutuVarmı(x, y - 1))
        {
            while (y > 0 && !KutuKontrol.KutuVarmı(x, y - 1))
            {
                y--;
            }
            this.y = (int)y;
            
            //transform.position = new Vector2(x, y);
        }
        if (this.y!=transform.position.y)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(x, y), KutuKontrol.KutuDüşmeHızı);
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
