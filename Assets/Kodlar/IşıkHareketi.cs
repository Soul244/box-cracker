using UnityEngine;
using System.Collections;

public class IşıkHareketi : MonoBehaviour {
    public Color[] renkler;
    int renkSira = 0;
    float zamanlayıcı = 4f;
	void Update () {
        zamanlayıcı -= Time.deltaTime;
        if (zamanlayıcı<=0)
        {
            zamanlayıcı = 4f;
            renkSira++;
            if (renkSira == renkler.Length)
            {
                renkSira = 0;
            }
        }
        Color anlıkRenk = GetComponent<Light>().color;
        GetComponent<Light>().color=Color.Lerp(anlıkRenk, renkler[renkSira],0.02f);

	}
}
