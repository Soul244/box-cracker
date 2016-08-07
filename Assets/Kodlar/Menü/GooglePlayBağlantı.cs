using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using System;

public class GooglePlayBağlantı : MonoBehaviour
{
    public GameObject mesaj;
    void BağlantıKur()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {

        });
    }
    void Start()
    {

        BağlantıKur();


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
            BağlantıKur();
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
            BağlantıKur();
        }
    }

    private void BağlantıYokMesajı()
    {
        Instantiate(mesaj);
    }
}


