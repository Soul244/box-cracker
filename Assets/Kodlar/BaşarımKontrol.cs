using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaşarımKontrol : MonoBehaviour
{
    bool ilk = false;
    bool yanlışTıklama = false;
    bool yaşamınSırrı = false;
    public static int patlatılanKutuSayısı;
    public static void YeniYüksekSkor(int yeniSkor)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(yeniSkor, BoxCrackerKaynak.leaderboard_high_scores, (bool başarılı) => { });
        }
    }
    public static void BaşarımAç(string başarımKodu)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(başarımKodu, 100, (bool başarı) => { });
        }
    }
    public static void KutuSayısıPatlamaKontrol(int patlayanKutuSayısı)
    {
        patlatılanKutuSayısı += patlayanKutuSayısı;
        if (patlayanKutuSayısı > 100000)
        {
            BaşarımAç(BoxCrackerKaynak.achievement_one_giant_leap_for_mankind);
        }
        else if (patlatılanKutuSayısı>50000)
        {
            BaşarımAç(BoxCrackerKaynak.achievement_50000_boxes);
        }
        else if (patlatılanKutuSayısı > 25000)
        {
            BaşarımAç(BoxCrackerKaynak.achievement_25000_boxes);
        }
        else if (patlayanKutuSayısı > 10000)
        {
            BaşarımAç(BoxCrackerKaynak.achievement_10000_boxes);
        }
        else if (patlatılanKutuSayısı>1000)
        {
            BaşarımAç(BoxCrackerKaynak.achievement_1000_boxes);
        }
        else if (patlatılanKutuSayısı > 41)
        {
            BaşarımAç(BoxCrackerKaynak.achievement_answer_to_life_the_universe_and_everything);
        }
    }
    // Use this for initialization
    void Start()
    {
        patlatılanKutuSayısı = PlayerPrefs.GetInt("PatlatılanKutuSayısı");
        ilk = PlayerPrefs.GetInt("İlkBaşarım") == 1;
        yanlışTıklama = PlayerPrefs.GetInt("YanlışTıklama") == 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ilk)
        {
            if (KutuKontrol.sonPuan > 0)
            {
                ilk = true;
                PlayerPrefs.SetInt("İlkBaşarım", 0);
                BaşarımAç(BoxCrackerKaynak.achievement_that_is_one_small_step_for_man);
            }
        }
        if (!yanlışTıklama)
        {
            if (KutuKontrol.sonPuan < 0)
            {
                yanlışTıklama = true;
                PlayerPrefs.SetInt("YanlışTıklama", 0);
                BaşarımAç(BoxCrackerKaynak.achievement_there_is_a_snake_inside);
            }
        }
    }
}
