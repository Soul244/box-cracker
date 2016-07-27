using UnityEngine;
using GooglePlayGames;
public class BaşarımSayfasıAç : MonoBehaviour {
    int tkutu;
    public string Başarım1;
    void Awake()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
        tkutu = PlayerPrefs.GetInt("ToplamPatlatılanKutu");
    }
    void Start()
    {
        Social.localUser.Authenticate(
            ( bool success) => {
            });
        if (tkutu>1000)
        {
            Social.ReportProgress(Başarım1, 100.0f, (bool success) => { });
        }
    }
    public void SayfaAç()
    {
            Social.ShowAchievementsUI();
    }
}
