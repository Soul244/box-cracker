using UnityEngine;
using System.Collections;

public class Kutu : MonoBehaviour
{
    public KutuÖzelliği kutuCinsi;
    public enum KutuÖzelliği
    {
        Normal,
        Parlak,
        Siyah,
        Patlak,
        Süre
    }
    public virtual Color Renk
    {
        get { return GetComponent<Renderer>().material.color; }
    }
    int x, y;
    public bool Süre
    {
        get
        {
            return kutuCinsi == KutuÖzelliği.Süre;
        }
    }
    public bool Normal
    {
        get
        {
            return kutuCinsi == KutuÖzelliği.Normal;
        }
    }
    public bool Siyah
    {
        get
        {
            return kutuCinsi == KutuÖzelliği.Siyah;
        }
    }
    public bool Parlak
    {
        get
        {
            return kutuCinsi == KutuÖzelliği.Parlak;
        }
    }
    public bool Patlak
    {
        get
        {
            return kutuCinsi==KutuÖzelliği.Patlak;
        }

        set
        {
            kutuCinsi = value ? KutuÖzelliği.Patlak:kutuCinsi;
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
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        kaybolmaSayacı = KutuKontrol.patlamaEfektiSüresi;
    }
    void OnMouseUpAsButton()
    {

        if (!KutuKontrol.patlamaVar && !AraMenüFonksiyonları.oyunDurdu)
        {
            int kutuÖzelliği = -1;
            if (kutuCinsi==KutuÖzelliği.Parlak)
            {
                kutuÖzelliği = 0;
            }
            else if (kutuCinsi == KutuÖzelliği.Siyah)
            {
                kutuÖzelliği = 1;
            }
            else if (kutuCinsi==KutuÖzelliği.Süre)
            {
                kutuÖzelliği = 2;
            }
            PuanGöster.yeniKutuyaTıklanıldı = true;
            KutuKontrol.tıklananKutu = new Vector3(x, y, kutuÖzelliği);
        }
    }
    public void Patlat(GameObject PatlamaEfekti)
    {
        kutuCinsi = KutuÖzelliği.Patlak;
        Instantiate(PatlamaEfekti, new Vector3(x, y, transform.position.z - 0.5f), Quaternion.identity);
        KutuKontrol.patlamaVar = patlamaDurumu = true;

    }
    public bool AynıRenk(Kutu DiğerKutu)
    {
        if (DiğerKutu == null)
            return false;
        return Renk == DiğerKutu.Renk;
    }
    

    // Update is called once per frame
    protected void Update()
    {
        if (patlamaDurumu)
        {
            kaybolmaSayacı -= Time.deltaTime;
            if (kaybolmaSayacı <= 0)
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
        }
        if (this.y != transform.position.y)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(x, y), KutuKontrol.KutuDüşmeHızı * Time.deltaTime);
        }
    }
}
