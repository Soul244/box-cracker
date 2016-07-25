using UnityEngine;
using System.Collections;

public class BaşarımKontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (KutuKontrol.sonPuan>99)
        {
            BaşarımKontrolü.BaşarımAç("Çüş");
        }
	}
}
