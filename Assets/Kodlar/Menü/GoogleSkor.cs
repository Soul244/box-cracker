using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GoogleSkor : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        //PlayGamesPlatform.Activate();
        //PlayGamesPlatform.DebugLogEnabled = true;
    }
    void Start () {
        //Social.localUser.Authenticate(
        //(bool success) => {
        //});
        //if (Social.localUser.authenticated)
        //{
        //    Social.ReportScore(PlayerPrefs.GetInt("High Score"), "CgkI1p743fUHEAIQAw", (bool success) =>
        //    {
        //        if (success)
        //        {
        //            GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı Var";
        //        }
        //        else {
        //            GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı yok2";
        //        }
        //    });
        //}
        //else
        //{
        //    GameObject.Find("BağlantıTestYazısı").GetComponent<UnityEngine.UI.Text>().text = "Bağlantı Yok";
        //}
    }

    public void skorGöster()
    {

    }
}
