using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using System;

public class GooglePlayBağlantı : MonoBehaviour
{
    GUIStyle centeredStyle;
    bool mesajGöster = false;
    float mesajZamanlayıcı = 6f;
    public Texture2D mesajArkaplan;
    void Start()
    {
        mesajGöster = false;

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
        mesajGöster = true;
    }
    void BağlantıYokMesajıGöster()
    {
        centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;
        GUI.Label(new Rect(Screen.width / 2 - 87.5f, Screen.height - 90, 175, 50), mesajArkaplan, centeredStyle);
        mesajZamanlayıcı -= Time.deltaTime;
        mesajGöster = mesajZamanlayıcı > 0;
        mesajZamanlayıcı = mesajGöster ? mesajZamanlayıcı : 6f;
    }
    public void OnGUI()
    {
        if (mesajGöster)
        {
            BağlantıYokMesajıGöster();
        }
    }
}


