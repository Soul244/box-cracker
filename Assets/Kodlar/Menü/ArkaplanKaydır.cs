using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArkaplanKaydır : MonoBehaviour {
    Image resim;
    bool cevir = true;
	// Use this for initialization
	void Start () {
        resim = GetComponent<Image>();

    }
	// Update is called once per frame
	void Update () {
        kaydir();
	}
    void kaydir()
    {
        if (cevir)
        {
            resim.transform.position = new Vector3(resim.transform.position.x + 1, resim.transform.position.y, resim.transform.position.z);
            if (resim.transform.position.x >= 400)
            {
                cevir = false;
            }
        }
        else
        {
            resim.transform.position = new Vector3(resim.transform.position.x - 1, resim.transform.position.y, resim.transform.position.z);
            if (resim.transform.position.x<=-75)//X değeri unity üzerindeki X konumuyla niyeyse uyuşmuyor. -75'i deneme yanılmayla buldum. 
            {
                cevir = true;
            }
        }
    }
}
