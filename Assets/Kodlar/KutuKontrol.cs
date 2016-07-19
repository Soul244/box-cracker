using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class KutuKontrol : MonoBehaviour
{
    [Space(15)]
    [Header("Kutular")]
    public GameObject kutu;
    public GameObject parlakKutu;
    public GameObject siyahKutu;
    [Space(15)]
    [Header("Efektler")]
    public GameObject patlamaEfekti;
    [Space(15)]
    [Header("Kutu Sayıları")]
    [Range(1, 10)]
    public int Genişlik = 6;
    public static int genişlik = 6;
    [Range(1, 10)]
    public int Yükseklik = 8;
    public static int yükseklik = 8;
    public int kutuSayısı = 64;
    [Space(15)]
    public static Vector3 tıklananKutu = new Vector3(-1, -1, -1);
    Color[] renkler = new Color[] { Color.red, Color.blue, Color.yellow, Color.green };
    [Header("Bölüm Geçme Koşulları")]
    public int yıldız1;
    public int yıldız2;
    public int yıldız3;
    [Space(15)]
    [Header("Özel Kutu Gelme Şansı")]
    [Tooltip("1000 üzerinden değerlendirilir")]
    public int parlakKutuŞansı = 50;
    [Tooltip("1000 üzerinden değerlendirilir")]
    public int siyahKutuŞansı = 100;
    [Space(15)]
    [Header("Arkaplan Özellikleri")]
    public GameObject arkaplanNesnesi;
    public Material[] arkaplanMateryalleri;
    public Dictionary<string, int> renkSayıları;
    [Space(15)]
    [Header("Patlama Efektleri")]
    public GameObject[] patlamaEfektleri;
    public float patlamaEfektiKalmaSüresi=0.15f;
    public static float patlamaEfektiSüresi;
    Dictionary<Color, string> RenkTanımlayıcı;
    public static bool patlamaVar=false;
    int puan = 0;
    public static int sonPuan = 0;
    float kontrolZamanlayıcı = 1f;
    [Space(15)]
    [Header("Artı Süre Silme Süresi")]
    public static float artSüreSil = 0.15f;
    void RenkTanımla()
    {
        RenkTanımlayıcı = new Dictionary<Color, string>();
        RenkTanımlayıcı.Add(Color.red, "Red");
        RenkTanımlayıcı.Add(Color.blue, "Blue");
        RenkTanımlayıcı.Add(Color.yellow, "Yellow");
        RenkTanımlayıcı.Add(Color.green, "Green");
        RenkTanımlayıcı.Add(Color.white, "Bomb");
    }
    void Awake()
    {
        patlamaEfektiSüresi = patlamaEfektiKalmaSüresi;
        genişlik = Genişlik;
        yükseklik = Yükseklik;
        RenkTanımla();
        renkSayıları = new Dictionary<string, int>();
        foreach (Color item in renkler)
        {
            renkSayıları.Add(RenkTanımlayıcı[item], 0);
        }
        renkSayıları.Add("Bomb", 0);
    }
    void Start()
    {
        //arkaplanNesnesi.GetComponent<Renderer>().material = arkaplanMateryalleri[UnityEngine.Random.Range(0, arkaplanMateryalleri.Length - 1)];
    }
    public static Kutu KutuVarmı(float x, float y)
    {
        Kutu[] kutular = FindObjectsOfType<Kutu>();
        foreach (Kutu item in kutular)
        {
            if ((Vector2)item.transform.position == new Vector2(x, y))
            {
                return item;
            }
        }
        return null;
    }
    void KutuKoy(float x, float y)
    {
        int şans = UnityEngine.Random.Range(0, 1000);
        int index = UnityEngine.Random.Range(0, renkler.Length);
        Color kutuRengi = renkler[index];
        GameObject temp;
        if (şans < siyahKutuŞansı)
        {
            temp = (GameObject)Instantiate(siyahKutu, new Vector2(x, y), Quaternion.identity);
            kutuRengi = Color.white;
        }
        else if (şans < parlakKutuŞansı)
        {
            temp = (GameObject)Instantiate(parlakKutu, new Vector2(x, y), Quaternion.identity);
            temp.GetComponent<Renderer>().material.SetColor("_SpecColor", kutuRengi);
        }
        else {

            temp = (GameObject)Instantiate(kutu, new Vector2(x, y), Quaternion.identity);

        }
        renkSayıları[RenkTanımlayıcı[kutuRengi]]++;
        temp.GetComponent<Renderer>().material.color = kutuRengi;
    }
    public void KutularıKaldır(List<Kutu> Kutular)
    {
        foreach (Kutu item in Kutular)
        {
            renkSayıları[RenkTanımlayıcı[item.GetComponent<Renderer>().material.color]]--;
            item.Patlat(patlamaEfektleri[UnityEngine.Random.Range(0,3)]);
        }
    }
    void BölümüBitirme()
    {
        if (HamleKaldımı() == false)// YAPILACAK HAMLE KALMADIYSA OYUNU BİTİR
        {
            //Application.LoadLevel("Anamenü");
            //SceneManager.LoadScene("Ana Menü");
            int öncekiPuan = PlayerPrefs.GetInt("High Score");
            if (puan < öncekiPuan)
            {
                //if (puan >= yıldız1 && puan < yıldız2) SesOynat("Kazanma 1 Yıldız");
                //else if (puan >= yıldız2 && puan < yıldız3) SesOynat("Kazanma 2 Yıldız");
                //else if (puan >= yıldız3) SesOynat("Kazanma 3 Yıldız");
                //return;
            }
            else
            {
                PlayerPrefs.SetInt("High Score", puan);
                //    if (puan >= yıldız1 && puan < yıldız2)
                //    {
                //        SesOynat("Kazanma 1 Yıldız");
                //        Debug.Log(puan.ToString());
                //        sonrakiBolum = int.Parse(Application.loadedLevelName) + 1;
                //        PlayerPrefs.SetInt("Level " + sonrakiBolum.ToString() + " Buton", 1);
                //        PlayerPrefs.SetInt("Level " + Application.loadedLevelName + " Buton", 2);
                //    }
                //    else if (puan >= yıldız2 && puan < yıldız3)
                //    {
                //        SesOynat("Kazanma 2 Yıldız");
                //        Debug.Log("iki yıldız");
                //        sonrakiBolum = int.Parse(Application.loadedLevelName) + 1;
                //        PlayerPrefs.SetInt("Level " + sonrakiBolum.ToString() + " Buton", 1);
                //        PlayerPrefs.SetInt("Level " + Application.loadedLevelName + " Buton", 3);
                //    }
                //    else if (puan >= yıldız3)
                //    {
                //        SesOynat("Kazanma 3 Yıldız");
                //        Debug.Log("üç yıldız");
                //        sonrakiBolum = int.Parse(Application.loadedLevelName) + 1;
                //        PlayerPrefs.SetInt("Level " + sonrakiBolum.ToString() + " Buton", 1);
                //        PlayerPrefs.SetInt("Level " + Application.loadedLevelName + " Buton", 4);
                //    }
            }
        }
        //0 = Bölüm kitli
        //1= Bölüm Açık
        //2 = 1 Yıldız
        //3 = 2 Yıldız
        //4 = 3 YIldız
    }

    List<Kutu> AynıRenkliKutularıAl(Color Renk)
    {
        List<Kutu> patlatılacakKutular = new List<Kutu>();
        foreach (Kutu item in FindObjectsOfType<Kutu>())
        {
            Renderer rend = item.GetComponent<Renderer>();
            if (rend != null)
            {
                if (rend.material.color == Renk)
                {
                    patlatılacakKutular.Add(item);
                }
            }
        }
        return patlatılacakKutular;
    }
    List<Kutu> EtrafındakiKutularıAl(Kutu kontrolKutusu)
    {
        List<Kutu> etrafdakiKutular = new List<Kutu>();
        Vector2 p = kontrolKutusu.transform.position;
        Kutu yanKutu;
        yanKutu = KutuVarmı(p.x - 1, p.y);     //Sol
        if (yanKutu != null)
        {
            etrafdakiKutular.Add(yanKutu);
        }
        yanKutu = KutuVarmı(p.x - 1, p.y + 1); //SolÜst
        if (yanKutu != null)
        {
            etrafdakiKutular.Add(yanKutu);
        }
        yanKutu = KutuVarmı(p.x, p.y + 1);     //Üst
        if (yanKutu != null)
        {
            etrafdakiKutular.Add(yanKutu);
        }
        yanKutu = KutuVarmı(p.x + 1, p.y + 1); //SağÜst
        if (yanKutu != null)
        {
            etrafdakiKutular.Add(yanKutu);
        }
        yanKutu = KutuVarmı(p.x + 1, p.y);     //Sağ
        if (yanKutu != null)
        {
            etrafdakiKutular.Add(yanKutu);
        }
        yanKutu = KutuVarmı(p.x + 1, p.y - 1); //SağAlt
        if (yanKutu != null)
        {
            etrafdakiKutular.Add(yanKutu);
        }
        yanKutu = KutuVarmı(p.x, p.y - 1);     //Alt
        if (yanKutu != null)
        {
            etrafdakiKutular.Add(yanKutu);
        }
        yanKutu = KutuVarmı(p.x - 1, p.y - 1); //SolAlt
        if (yanKutu != null)
        {
            etrafdakiKutular.Add(yanKutu);
        }
        return etrafdakiKutular;
    }
    int SiyahKutuPatlaması(Kutu SeçilenKutu)
    {
        List<Kutu> patlatılacakKutular = EtrafındakiKutularıAl(SeçilenKutu);
        int puan = 0;
        foreach (Kutu item in patlatılacakKutular)
        {
            if (!item.Patlak && item.siyah)
            {
                item.Patlak = true;
                puan += SiyahKutuPatlaması(item);
            }
        }
        patlatılacakKutular.Add(SeçilenKutu);
        KutularıKaldır(patlatılacakKutular);
        return Puanla(patlatılacakKutular) + puan;
    }
    void Update()
    {
        patlamaEfektiSüresi = patlamaEfektiKalmaSüresi; // Oyun son haldeyken bu satır silenecek. Deneme amaçlı
        kontrolZamanlayıcı -= Time.deltaTime;
        if (kutuSayısı > 0)
        {
            for (int x = 0; x < genişlik; x++)
            {
                if (!KutuVarmı(x, yükseklik - 1))
                {
                    KutuKoy(x, yükseklik - 1);
                    kutuSayısı--;

                }
            }
        }
        if (tıklananKutu != new Vector3(-1, -1, -1))
        {
            Kutu seçilenKutu = KutuVarmı(tıklananKutu.x, tıklananKutu.y);
            List<Kutu> patlatılacakKutular;
            if (tıklananKutu.z == 0) //Tıklanan Kutu Parlaksa
            {
                patlatılacakKutular = AynıRenkliKutularıAl(seçilenKutu.GetComponent<Renderer>().material.color);
                sonPuan= Puanla(patlatılacakKutular);
                puan += sonPuan;
                KutularıKaldır(patlatılacakKutular);
                kontrolZamanlayıcı = 1f;
                SesOynat("Patlama Sesi 1");
            }
            else if (tıklananKutu.z == 1) //Tıklanan Kutu Siyahsa
            {
                sonPuan = SiyahKutuPatlaması(seçilenKutu);
                puan += sonPuan;
                kontrolZamanlayıcı = 1f;
                SesOynat("Patlama Sesi 1");
            }
            else //Normal Kutuya Tıklandıysa
            {
                patlatılacakKutular = TaşırmaAlgoritması((int)tıklananKutu.x, (int)tıklananKutu.y, new bool[genişlik, yükseklik], seçilenKutu.GetComponent<Renderer>().material.color);
                if (patlatılacakKutular.Count > 2)
                {
                    sonPuan = Puanla(patlatılacakKutular);
                    puan += sonPuan;
                    KutularıKaldır(patlatılacakKutular);
                    kontrolZamanlayıcı = 1f;
                    SesOynat("Patlama Sesi 1");
                }
                else
                {
                    SesOynat("Boş Tıklama 1");
                }
            }
            tıklananKutu = new Vector3(-1, -1, -1);

        }
        if (kontrolZamanlayıcı <= 0)
        {
            BölümüBitirme();
            kontrolZamanlayıcı = 1f;
        }

    }

    private void SesOynat(string ObjeAdı)
    {
        GameObject.Find(ObjeAdı).GetComponent<AudioSource>().Play();
    }

    public bool HamleKaldımı()
    {
        for (int x = 0; x < genişlik; x++)
        {
            if( KutuVarmı(x, 0)==null)
            {
                break;
            }
            for (int y = 0; y < yükseklik; y++)
            {
                List<Kutu> patlatılacakKutular = new List<Kutu>();
                Kutu geç = KutuVarmı(x, y);
                if (geç==null)
                {
                    break;
                }
                if (geç != null)
                {
                    if (!geç.Patlak)
                    {
                        if (geç.parlak)
                        {
                            return true;
                        }
                        else if (geç.GetComponent<Renderer>().material.color == Color.black)
                        {
                            return true;
                        }
                        patlatılacakKutular = TaşırmaAlgoritması((int)geç.transform.position.x, (int)geç.transform.position.y, new bool[genişlik, yükseklik], geç.GetComponent<Renderer>().material.color);
                        if (patlatılacakKutular.Count > 2)
                        {
                            return true;
                        }
                    }
                }

            }
        }
        return false;
    }
    public static int Puanla(List<Kutu> patlayanlar)
    {
        int puan = 1, çoklayıcı = 1;
        çoklayıcı = patlayanlar.Count / 2;
        puan = patlayanlar.Count * çoklayıcı;
        GameObject.Find("Skor").GetComponent<TextMesh>().text = Convert.ToString(puan + Convert.ToInt32(GameObject.Find("Skor").GetComponent<TextMesh>().text));
        double süre = puan * 0.01;
        GameObject.Find("Artı Süre").GetComponent<TextMesh>().text = "+" + süre;
        artısüreyisil(artSüreSil);
        GameObject.Find("Süre").GetComponent<TextMesh>().text = Convert.ToString(Convert.ToDouble(GameObject.Find("Süre").GetComponent<TextMesh>().text) + süre);
        return puan;
    }
    static bool EtrafındaAynıRenkVarmı(float x, float y)
    {
        Kutu k = KutuVarmı(x, y);
        if (k != null)
        {
            if (k.AynıRenk(KutuVarmı(x, y + 1)))
            {
                return true;
            }
            else if (k.AynıRenk(KutuVarmı(x, y - 1)))
            {
                return true;
            }
            else if (k.AynıRenk(KutuVarmı(x + 1, y)))
            {
                return true;
            }
            else if (k.AynıRenk(KutuVarmı(x - 1, y)))
            {
                return true;
            }
        }
        return false;
    }
    public static List<Kutu> TaşırmaAlgoritması(int x, int y, bool[,] kontrolEdildi, Color Renk)
    {
        List<Kutu> patlayacak = new List<Kutu>();
        if (x >= 0 && y >= 0 && x < genişlik && y < yükseklik)
        {
            if (kontrolEdildi[x, y])
            {
                return patlayacak;
            }
            Kutu geç = KutuVarmı(x, y);
            if (geç != null)
            {
                if (!geç.Patlak)
                {
                    if (geç.GetComponent<Renderer>().material.color == Renk)
                    {
                        patlayacak.Add(geç);

                    }
                    else
                    {
                        return patlayacak;
                    }
                }
            }
            if (!EtrafındaAynıRenkVarmı(x, y))
            {
                return patlayacak;
            }
            kontrolEdildi[x, y] = true;
            patlayacak.AddRange(TaşırmaAlgoritması(x - 1, y, kontrolEdildi, Renk));
            patlayacak.AddRange(TaşırmaAlgoritması(x + 1, y, kontrolEdildi, Renk));
            patlayacak.AddRange(TaşırmaAlgoritması(x, y - 1, kontrolEdildi, Renk));
            patlayacak.AddRange(TaşırmaAlgoritması(x, y + 1, kontrolEdildi, Renk));
        }
        return patlayacak;
    }
    public static void artısüreyisil(float artsüre)
    {
        artsüre-= Time.deltaTime;
        if (artsüre <= 0)
        {
            GameObject.Find("Artı Süre").GetComponent<TextMesh>().text = "";
        }
    }
}
