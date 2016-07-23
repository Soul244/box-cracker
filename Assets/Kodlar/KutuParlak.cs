using UnityEngine;
using System.Collections;

public class KutuParlak : Kutu
{
    Renderer rend;
    [Range(0, 0.5f)]
    public float zamanlayıcı = 0.08f;
    [Range(0, 0.1f)]
    public float renkPayı = 0.016f;
    bool beyazlaştır;

    Color hasRenk;
    public override Color Renk
    {
        get
        {
            return hasRenk;
        }
    }
    // Use this for initialization
    void Start()
    {
        parlak = true;
        Patlak = false;
        rend = GetComponent<Renderer>();
        hasRenk = rend.material.color;
        beyazlaştır = true;
    }
    void Update()
    {
        base.Update();
        Color anlıkRenk = rend.material.color;
        if (beyazlaştır)
        {
            rend.material.color = Color.Lerp(anlıkRenk, Color.white, KutuKontrol._RenkZamanlayıcı);
            if (anlıkRenk.b > 1 - KutuKontrol._RenkPayı && anlıkRenk.g > 1 - KutuKontrol._RenkPayı && anlıkRenk.r > 1 - KutuKontrol._RenkPayı)
            {
                beyazlaştır = false;
            }
        }
        else
        {
            rend.material.color = Color.Lerp(anlıkRenk, hasRenk, KutuKontrol._RenkZamanlayıcı);
            beyazlaştır = anlıkRenk == hasRenk;
        }

    }
}
