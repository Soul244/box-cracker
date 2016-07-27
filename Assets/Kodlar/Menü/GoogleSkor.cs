using UnityEngine;
using System.Collections;
using GooglePlayGames;
public class GoogleSkor : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
    }
    void Start () {
        Social.localUser.Authenticate(
        (bool success) => {
        });
        Social.ReportScore(PlayerPrefs.GetInt("High Score"), "CgkI1p743fUHEAIQAw", (bool success) => {
            // handle success or failure
        });
    }

    public void skorGöster()
    {
        Social.ShowAchievementsUI();
    }
}
