using UnityEngine;
using System.Collections;

public class ArkaplanRenkDeğişimi : MonoBehaviour {
    public Color[] renkler;
    int renkSira = 0;
    float zamanlayıcı = 4f;
    // Update is called once per frame
    void Update()
    {
        zamanlayıcı -= Time.deltaTime;
        if (zamanlayıcı <= 0)
        {
            zamanlayıcı = 4f;
            renkSira++;
            if (renkSira == renkler.Length)
            {
                renkSira = 0;
            }
        }
        Color anlıkRenk = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.Lerp(anlıkRenk, renkler[renkSira], 0.02f);
    }
}
