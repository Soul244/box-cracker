using UnityEngine;
using System.Collections;

public class PatlamaSüresi : MonoBehaviour {
    float süre = KutuKontrol.patlamaEfektiSüresi;
	void Update () {
        süre -= Time.deltaTime;
        if (süre<=0)
        {
            Destroy(gameObject);
        }
	}
}
