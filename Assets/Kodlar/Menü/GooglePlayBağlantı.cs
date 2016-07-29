using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using System;

public class GooglePlayBağlantı : MonoBehaviour
{
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()

     .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        //PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
            {
                BağlantıYokMesajı();
            });

    }
    public void YüksekSkorlarAç()
    {
        GetComponent<AudioSource>().Play();
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            BağlantıYokMesajı();
        }
    }
    public void BaşarımlarıAç()
    {
        GetComponent<AudioSource>().Play();

        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            BağlantıYokMesajı();
        }
    }

    private void BağlantıYokMesajı()
    {
        
    }
}


