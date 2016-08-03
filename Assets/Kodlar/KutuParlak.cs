using UnityEngine;
using System.Collections;

public class KutuParlak : Kutu
{
    Renderer rend;
    [Range(0, 0.5f)]
    public float zamanlayıcı = 0.236f;
    [Range(0, 0.1f)]
    public float renkPayı = 0.1f;
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
        kutuCinsi = KutuÖzelliği.Parlak;
        rend = GetComponent<Renderer>();
        hasRenk = rend.material.color;
        beyazlaştır = true;
    }
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    void Update()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    {
        base.Update();
        Color anlıkRenk = rend.material.color;
        if (beyazlaştır)
        {
            rend.material.color = Color.Lerp(anlıkRenk, Color.white, zamanlayıcı);
            if (anlıkRenk.b > 1 - renkPayı && anlıkRenk.g > 1 - renkPayı && anlıkRenk.r > 1 - renkPayı)
            {
                beyazlaştır = false;
            }
        }
        else
        {
            rend.material.color = Color.Lerp(anlıkRenk, hasRenk, zamanlayıcı);
            beyazlaştır = anlıkRenk == hasRenk;
        }

    }
}
