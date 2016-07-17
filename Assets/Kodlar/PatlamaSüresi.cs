using UnityEngine;
using System.Collections;

public class PatlamaSüresi : MonoBehaviour {
    float süre = KutuKontrol.patlamaEfektiSüresi;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        süre -= Time.deltaTime;
        if (süre<=0)
        {
            Destroy(gameObject);
        }
	}
}
