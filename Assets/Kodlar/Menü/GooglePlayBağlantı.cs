using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class GooglePlayBağlantı : MonoBehaviour
{
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()

     .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
            {

            });

    }
    public void YüksekSkorlarAç()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı Yok";
        }
    }
    public void BaşarımlarıAç()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı Yok";
        }
    }
}


