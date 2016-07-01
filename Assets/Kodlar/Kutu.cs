using UnityEngine;
using System.Collections;

public class Kutu : MonoBehaviour {
    bool patlak;
    public bool parlak;
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
    void OnMouseUpAsButton()
    {
        int kutuÖzelliği = -1;
        if (parlak)
        {
            kutuÖzelliği = 0;
        }
        else if (GetComponent<Renderer>().material.color==Color.black)
        {
            kutuÖzelliği = 1;
        }
        KutuKontrol.tıklananKutu = new Vector3(transform.position.x,transform.position.y,kutuÖzelliği);
    }
    public void Patlat()
    {
        patlak = true;
        Destroy(gameObject);
    }
    public bool AynıRenk(Kutu DiğerKutu)
    {
        if (DiğerKutu == null)
            return false;
        return GetComponent<Renderer>().material.color == DiğerKutu.GetComponent<Renderer>().material.color;
    }
	// Use this for initialization
	void Start () {
        patlak = false;
	}
	
	// Update is called once per frame
	void Update () {
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
        else if (y==0 && !KutuKontrol.KutuVarmı(x-1,0))
        {
            while (x>0 && !KutuKontrol.KutuVarmı(x-1,0))
            {
                x--;
            }
            transform.position = new Vector2(x, y);
        }
    }
}
