using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class BaşarımKontrolü : MonoBehaviour {

    public GameObject başarımNesnesi;
    public Sprite[] başarımResimleri;
    public Sprite açıkBaşarıResmi;
    Dictionary<string, Başarım> başarımlar = new Dictionary<string, Başarım>();
    private static BaşarımKontrolü nesne;

    public static BaşarımKontrolü Nesne
    {
        get
        {
            if (nesne==null)
            {
                nesne = GameObject.FindObjectOfType<BaşarımKontrolü>();
            }
            return BaşarımKontrolü.nesne;
        }
    }

    public class Başarım
    {
        GameObject nesne;
        bool kazanıldı;
        public Sprite Resim
        {
            set
            {
                nesne.transform.GetChild(3).GetComponent<Image>().sprite = value;
            }
        }
        public GameObject Nesne
        {
            get
            {
                return nesne;
            }
        }

        public string Başlık
        {
            get
            {
                return nesne.transform.GetChild(0).GetComponent<Text>().text;
            }

            set
            {
                nesne.transform.GetChild(0).GetComponent<Text>().text = value;
            }
        }

        public string Açıklama
        {
            get
            {
                return nesne.transform.GetChild(1).GetComponent<Text>().text;
            }

            set
            {
                nesne.transform.GetChild(1).GetComponent<Text>().text = value;
            }
        }

        public Başarım(GameObject nesne, string başlık, string açıklama)
        {
            nesne.transform.SetParent(GameObject.Find("Genel").transform);
            nesne.transform.localScale = new Vector3(1, 1, 1);
            this.nesne = nesne;
            kazanıldı = false;
            //Resim = resim;
            Başlık = başlık;
            Açıklama = açıklama;
            BaşarımYükle();

        }
        public void Kaydet(bool açık)
        {
            kazanıldı = açık;
            PlayerPrefs.SetInt(Başlık, kazanıldı ? 1 : 0);
            PlayerPrefs.Save();
        }
        public bool BaşarımAç()
        {
            if (!kazanıldı)
            {
                nesne.GetComponent<Image>().sprite = BaşarımKontrolü.Nesne.açıkBaşarıResmi;
                kazanıldı = true;
                Kaydet(true);
                return true;
            }
            return false;
        }
        public void BaşarımYükle()
        {
            kazanıldı = PlayerPrefs.GetInt(Başlık) == 1 ? true : false;
            if (kazanıldı)
            {
                nesne.GetComponent<Image>().sprite = BaşarımKontrolü.Nesne.açıkBaşarıResmi;
            }
        }
    }
    void Start()
    {
        BaşarımKoy();
    }
    public void BaşarımAç(string BaşarımAdı)
    {
        başarımlar[BaşarımAdı].BaşarımAç();
    }
    public void BaşarımKoy() //Eklemek istediğin başarımları buraya yazarsın
    {
        Başarım başarı= new Başarım( Instantiate(başarımNesnesi),"Test1","Yok arkadaşım"); //Her Başarım için bunun gibi 2 satır yazmak zorundasın. Burda Test1 başarımın adı ve Yok Arkadaşım kısmı ise başarımın koşulları olacak.
        başarımlar.Add(başarı.Başlık, başarı); // Yazmayı unutma
    }
}
