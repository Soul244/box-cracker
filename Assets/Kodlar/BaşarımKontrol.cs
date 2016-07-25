using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaşarımKontrol : MonoBehaviour {
    public GameObject BaşarımObjesi;
	// Use this for initialization
	void Start () {
        BaşarımObjesi = GameObject.Find("AçılanBaşarımResmi");
	}
	
	// Update is called once per frame
	void Update () {
        if (KutuKontrol.sonPuan>99)
        {
            BaşarımKontrolü.BaşarımAç("Çüş");
            BaşarımObjesi.GetComponent<Renderer>().material.color = Color.white;
            BaşarımObjesi.transform.GetChild(1).GetComponent<Text>().text = "Çüş";
        }
	}
}
