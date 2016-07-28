using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class BaşarımSayfasıAç : MonoBehaviour {
    int tkutu;
    public string Başarım1;
    void Awake()
    {
        //PlayGamesPlatform.Activate();
        //PlayGamesPlatform.DebugLogEnabled = true;
        tkutu = PlayerPrefs.GetInt("ToplamPatlatılanKutu");
    }
    void Start()
    {
        //Social.localUser.Authenticate(
        //    ( bool success) => {
        //    });
        //if (Social.localUser.authenticated)
        //{
        //    if (tkutu > 1000)
        //    {
        //        Social.ReportProgress(Başarım1, 100.0f, (bool success) => { if (success) GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı Var";
        //            else { GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı yok2"; } });
        //    }
        //}
        //else
        //{
        //    GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı Yok";
        //}
    }
    public void SayfaAç()
    {
        if (Social.localUser.authenticated)
        {
            if (tkutu > 1000)
            {
                Social.ReportProgress(Başarım1, 100.0f, (bool success) => {
                    if (success) GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı Var";
                    else { GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı yok2"; }
                });
            }
            Social.ShowAchievementsUI();
        }
        else
        {
            GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı Yok";
        }


    }
}
