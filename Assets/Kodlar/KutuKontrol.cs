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
    public GameObject süreKutu;
    [Space(15)]
    [Header("Kutu Ayarları")]
    [Range(1, 10)]
    public int Genişlik = 6;
    public static int genişlik = 6;
    [Range(1, 10)]
    public int Yükseklik = 8;
    public static int yükseklik = 8;
    public int kutuSayısı = 64;
    [Range(1f, 50f)]
    public float kutuDüşmeHızı;
    public static float KutuDüşmeHızı;
    [Space(15)]
    public static Vector3 tıklananKutu = new Vector3(-1, -1, -1);
    Color[] renkler = new Color[] { Color.red, Color.blue, Color.yellow, Color.green };
    [Header("Özel Kutu Gelme Şansı")]
    [Tooltip("100 üzerinden değerlendirilir")]
    public float parlakKutuŞansı = 50;
    [Tooltip("100 üzerinden değerlendirilir")]
    public float siyahKutuŞansı = 100;
    [Tooltip("100 üzerinden değerlendirilir")]
    public float süreKutuŞansı = 2;
    [Space(15)]
    [Header("Patlama Efektleri")]
    public GameObject[] patlamaEfektleri;
    public float patlamaEfektiKalmaSüresi = 0.15f;
    public static float patlamaEfektiSüresi;
    [Space(15)]
    [Header("Puanlama Sistemi")]
    [Range(1, 5)]
    public float puanÇoklayıcı = 1f;
    public int puanEksiltmeOranı = 100;
    //Dictionary<Color, string> RenkTanımlayıcı;
    public static bool patlamaVar = false;
    int puan = 0;
    public static int toplamPuan;
    public static int sonPuan = 0;
    float kontrolZamanlayıcı = 6f;
    [Space(15)]
    [Header("Artı Süre Silme Süresi")]
    public float artSüreSilmeZamanı = 0.15f;
    [Space(15)]
    [Header("Geçici Değerler Silinecek")]
    [Range(0, 1)]
    public float renkZamanlayıcı;
    public static float _RenkZamanlayıcı;
    [Range(0, 0.1f)]
    public float renkPayı;
    public static float _RenkPayı;
    public static bool yankışKutuyaTıklandı = false;
    public static bool artıSüreyiGöster = false;
    float artSüreSil;
    void Awake()
    {
        #region Silinecek Değerler
        _RenkPayı = renkPayı;
        _RenkZamanlayıcı = renkZamanlayıcı;
        #endregion
        toplamPuan = 0;
        yankışKutuyaTıklandı = false;
        KutuDüşmeHızı = kutuDüşmeHızı;
        artSüreSil = artSüreSilmeZamanı;
        artıSüreyiGöster = false;
        patlamaVar = false;
        puanEksiltme = puanEksiltmeOranı;
        patlamaEfektiSüresi = patlamaEfektiKalmaSüresi;
        genişlik = Genişlik;
        yükseklik = Yükseklik;
    }
    void Start()
    {
        YüksekSkorKontrolü();
        PuanÇoklayıcı = puanÇoklayıcı;
        GameObject.Find("Artı Süre").GetComponent<TextMesh>().text = "";
    }
    public static Kutu KutuVarmı(float x, float y)
    {
        Kutu[] kutular = FindObjectsOfType<Kutu>();
        for (int i = 0; i < kutular.Length; i++)
        {
            if (kutular[i].X == x && kutular[i].Y == y)
            {
                return kutular[i];
            }
        }
        return null;
    }
    int ŞansKutusu(params float[] şansOranları)
    {
        float şans = UnityEngine.Random.Range(0, 100);
        Dictionary<float, int> yerTutma = new Dictionary<float, int>();
        for (int i = 0; i < şansOranları.Length; i++)
        {
            yerTutma.Add(şansOranları[i], i);
        }
        Array.Sort(şansOranları);
        for (int i = 0; i < şansOranları.Length; i++)
        {
            if (şans<şansOranları[i])
            {
                return yerTutma[şansOranları[i]];
            }
        }
        return -1;
    }
    void KutuKoy(float x, float y)
    {
        int index = UnityEngine.Random.Range(0, renkler.Length);
        Color kutuRengi = renkler[index];
        GameObject temp;
        int çıkanKutu = ŞansKutusu(new float[] { parlakKutuŞansı, siyahKutuŞansı,süreKutuŞansı });
        if (çıkanKutu==1)
        {
            temp = (GameObject)Instantiate(siyahKutu, new Vector2(x, y), Quaternion.identity);
            kutuRengi = Color.white;
        }
        else if (çıkanKutu==0)
        {
            temp = (GameObject)Instantiate(parlakKutu, new Vector2(x, y), Quaternion.identity);
            temp.GetComponent<Renderer>().material.SetColor("_SpecColor", kutuRengi);
        }
        else if (çıkanKutu==2)
        {
            temp = (GameObject)Instantiate(süreKutu, new Vector2(x, y), Quaternion.identity);
            temp.GetComponent<Renderer>().material.SetColor("_SpecColor", kutuRengi);
        }
        else {

            temp = (GameObject)Instantiate(kutu, new Vector2(x, y), Quaternion.identity);

        }
        temp.GetComponent<Renderer>().material.color = kutuRengi;
    }
    public void KutularıKaldır(List<Kutu> Kutular)
    {
        foreach (Kutu item in Kutular)
        {
            item.Patlat(patlamaEfektleri[UnityEngine.Random.Range(0, 3)]);
        }
    }
    void BölümüBitirme()
    {
        if (HamleKaldımı() == false)// YAPILACAK HAMLE KALMADIYSA OYUNU BİTİR
        {
            int öncekiPuan = PlayerPrefs.GetInt("High Score");
            if (puan < öncekiPuan)
            {

            }
            else
            {
                PlayerPrefs.SetInt("High Score", puan);
            }
            GameObject.Find("highscore").GetComponent<UnityEngine.UI.Text>().text = "High Score: " + PlayerPrefs.GetInt("High Score").ToString();
            GameObject.Find("score").GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameObject.Find("Skor").GetComponent<TextMesh>().text;
            GameObject.Find("Ara Menü").GetComponent<Canvas>().enabled = true;
            AraMenüFonksiyonları.oyunDurdu = AraMenüFonksiyonları.oyunBitti = true;
        }
    }

    List<Kutu> AynıRenkliKutularıAl(Color Renk)
    {
        List<Kutu> patlatılacakKutular = new List<Kutu>();
        foreach (Kutu item in FindObjectsOfType<Kutu>())
        {
            if (item != null)
            {
                if (item.Renk == Renk)
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
        Vector2 p = new Vector2(kontrolKutusu.X, kontrolKutusu.Y);
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
    float SiyahKutuPatlaması(Kutu SeçilenKutu)
    {
        List<Kutu> patlatılacakKutular = EtrafındakiKutularıAl(SeçilenKutu);
        float puan = 0;
        foreach (Kutu item in patlatılacakKutular)
        {
            if (!item.Patlak && item.Siyah)
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
        #region Son Sürümde Silinecek Kodlar
        patlamaEfektiSüresi = patlamaEfektiKalmaSüresi;
        PuanÇoklayıcı = puanÇoklayıcı;
        KutuDüşmeHızı = kutuDüşmeHızı;
        _RenkPayı = renkPayı;
        _RenkZamanlayıcı = renkZamanlayıcı;
        #endregion
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
            string oynatılacakPatlamaSesi = "Patlama Sesi " + UnityEngine.Random.Range(1, 3).ToString();
            List<Kutu> patlatılacakKutular;
            if (tıklananKutu.z == 0) //Tıklanan Kutu Parlaksa
            {
                patlatılacakKutular = AynıRenkliKutularıAl(seçilenKutu.Renk);
                sonPuan = Convert.ToInt32(Puanla(patlatılacakKutular));
                puan += sonPuan;
                KutularıKaldır(patlatılacakKutular);
                kontrolZamanlayıcı = 1f;
                SesOynat(oynatılacakPatlamaSesi);
            }
            else if (tıklananKutu.z == 1) //Tıklanan Kutu Siyahsa
            {
                sonPuan = Convert.ToInt32(SiyahKutuPatlaması(seçilenKutu));
                puan += sonPuan;
                kontrolZamanlayıcı = 1f;
                SesOynat(oynatılacakPatlamaSesi);
            }
            else //Normal Kutuya Tıklandıysa
            {
                patlatılacakKutular = TaşırmaAlgoritması((int)tıklananKutu.x, (int)tıklananKutu.y, new bool[genişlik, yükseklik], seçilenKutu.Renk);
                sonPuan = Convert.ToInt32(Puanla(patlatılacakKutular));
                if (patlatılacakKutular.Count > 2)
                {

                    puan += sonPuan;
                    KutularıKaldır(patlatılacakKutular);
                    kontrolZamanlayıcı = 1f;
                    SesOynat(oynatılacakPatlamaSesi);
                }
                else // Patlanamayacak durumda olan kutuya tıklandıysa
                {
                    sonPuan = 0 - puanEksiltmeOranı;
                    yankışKutuyaTıklandı = true;
                    puan -= puanEksiltmeOranı;
                    SesOynat("Boş Tıklama 1");
                }
            }
            PuanGöster.puanGösterilecekKutu = tıklananKutu;
            tıklananKutu = new Vector3(-1, -1, -1);
            YüksekSkorKontrolü();
            toplamPuan = puan;
        }
        if (kontrolZamanlayıcı <= 0)
        {
            BölümüBitirme();
            kontrolZamanlayıcı = 1f;
        }
        ArtıSüreyiAyarla();

    }
    void YüksekSkorKontrolü()
    {
        TextMesh yazılacakAlan = GameObject.Find("Yüksek Skor").GetComponent<TextMesh>();
        int geçmişYüksekSkor = PlayerPrefs.GetInt("High Score");
        yazılacakAlan.text = geçmişYüksekSkor > puan ? geçmişYüksekSkor.ToString() : puan.ToString();
    }
    private void SesOynat(string ObjeAdı)
    {
        if (SesAyarları.sesDurumu)
        {
            GameObject.Find(ObjeAdı).GetComponent<AudioSource>().Play();
        }
    }

    public bool HamleKaldımı()
    {
        for (int x = 0; x < genişlik; x++)
        {
            if (KutuVarmı(x, 0) == null)
            {
                break;
            }
            for (int y = 0; y < yükseklik; y++)
            {
                List<Kutu> patlatılacakKutular = new List<Kutu>();
                Kutu geç = KutuVarmı(x, y);
                if (geç == null)
                {
                    break;
                }
                if (!geç.Patlak)
                {
                    if (geç.Parlak || geç.Siyah)
                    {
                        return true;
                    }
                    patlatılacakKutular = TaşırmaAlgoritması((int)geç.X, (int)geç.Y, new bool[genişlik, yükseklik], geç.Renk);
                    if (patlatılacakKutular.Count > 2)
                    {
                        return true;
                    }

                }

            }
        }
        return false;
    }
    static int puanEksiltme;
    static float PuanÇoklayıcı;

    public static float Puanla(List<Kutu> patlayanlar)
    {
        if (patlayanlar.Count < 3)
        {
            GameObject.Find("Skor").GetComponent<TextMesh>().text = Convert.ToString(Convert.ToInt32(GameObject.Find("Skor").GetComponent<TextMesh>().text) - puanEksiltme);
            GameObject.Find("Artı Süre").GetComponent<TextMesh>().text = "-" + (puanEksiltme / 100).ToString("0.0");
            Süre.KalanSüre = Süre.KalanSüre - puanEksiltme / 100;
            artıSüreyiGöster = true;
            return puanEksiltme;
        }
        float puan = 1, çoklayıcı = 1;
        çoklayıcı = patlayanlar.Count / 2;
        puan = patlayanlar.Count * çoklayıcı;
        BaşarımKontrol.KutuSayısıPatlamaKontrol(patlayanlar.Count);
        puan *= PuanÇoklayıcı;
        GameObject.Find("Skor").GetComponent<TextMesh>().text = Convert.ToString((int)puan + Convert.ToInt32(GameObject.Find("Skor").GetComponent<TextMesh>().text));
        float süre = puan * 0.01f;
        foreach (Kutu item in patlayanlar)
        {
            if (item.Süre)
            {
                süre++; //Her süreli kutu için 1 saniye ekleme
            }
        }
        GameObject.Find("Artı Süre").GetComponent<TextMesh>().text = "+" + süre.ToString("0.0");
        artıSüreyiGöster = true;
        Süre.KalanSüre += süre;

        return (int)puan;
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
                    if (geç.Renk == Renk)
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
    public void ArtıSüreyiAyarla()
    {
        if (artıSüreyiGöster)
        {
            artSüreSil -= Time.deltaTime;
            if (artSüreSil <= 0)
            {
                GameObject.Find("Artı Süre").GetComponent<TextMesh>().text = "";
                artSüreSil = artSüreSilmeZamanı;
                artıSüreyiGöster = false;
            }
        }
    }
}
