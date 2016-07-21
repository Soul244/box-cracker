using UnityEngine;
using System.Collections;

public class PuanGöster : MonoBehaviour {
    public static Vector3 puanGösterilecekKutu;
    public static bool yeniKutuyaTıklanıldı;
    public GameObject puanGösterilecekObje;
	// Use this for initialization
	void Start () {
        yeniKutuyaTıklanıldı = false;
        puanGösterilecekKutu= new Vector3(-1,-1,-1);
	}
	
	// Update is called once per frame
	void Update () {
        if (yeniKutuyaTıklanıldı)
        {
            string gösterilecek = KutuKontrol.sonPuan < 0 ?KutuKontrol.sonPuan.ToString() : "+" + KutuKontrol.sonPuan.ToString();
            puanGösterilecekObje.GetComponent<TextMesh>().text = gösterilecek;
                Instantiate(puanGösterilecekObje, puanGösterilecekKutu, Quaternion.identity);
            yeniKutuyaTıklanıldı = false;
        }

    }
}
